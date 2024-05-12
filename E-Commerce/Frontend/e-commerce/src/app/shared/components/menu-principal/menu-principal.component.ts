import { Component, inject } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { CartComponent } from '../cart/cart.component';
import { CartService } from 'src/app/core/services/cart.service';

@Component({
  selector: 'app-menu-principal',
  templateUrl: './menu-principal.component.html',
  styleUrls: ['./menu-principal.component.css']
})
export class MenuPrincipalComponent {
  private readonly _dialog = inject(MatDialog);
  private readonly _shopCartService = inject(CartService)

  private _shoppingCartId?:number | null;

  isLogin$!:Observable<boolean>;
  quantityItemInCart$!: Observable<number>
  isAdmin$!:Observable<boolean>;
  areItems$!: Observable<boolean>;

  constructor(private loginService: LoginService) {}

    ngOnInit(): void {
        this.isLogin$ = this.loginService.isInLogin();        
        this.isAdmin$ = this.loginService.getIsAdmin();
        this.setShopCartId();
        this.getShopCart();
        this.quantityItemInCart$ = this._shopCartService.getQuantityItems();
        this.areItems$ = this._shopCartService.getAreItems();
    
    }

    onLogout():void{
      this.loginService.logout();
      this._shopCartService.setAreItems(false);
    }

    onShoppingCart(){
      let shopCartRef = this._dialog.open(CartComponent,{
        width:"500px",
        height:"100vh",
        position:{
          right:"0",
          top:"0"
        },
        disableClose: true
      })

    }

    private setShopCartId(){
      this.isLogin$.pipe().subscribe(value =>{
        if(value){
          this._shoppingCartId = this.loginService.getCurrentShopCartId();
        }
      })
    }

    private getShopCart(){
      if(this._shoppingCartId){
        this._shopCartService.getShopCart(this._shoppingCartId).subscribe( resp => {
          this._shopCartService.setQuantityItem(resp.data.cartItems.length);
          if(resp.data.cartItems.length > 0){
            this._shopCartService.setAreItems(true);
          }
        })
      }
    }
}
