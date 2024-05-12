import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { Subscription, tap, mergeMap, switchMap, of, Observable } from 'rxjs';
import { CartItem } from 'src/app/core/models/cartItem/cartItem';
import { Product } from 'src/app/core/models/product/product';
import { Response } from 'src/app/core/models/response';
import { ShoppingCart } from 'src/app/core/models/shoppingCart/shoppingCart';
import { CartService } from 'src/app/core/services/cart.service';
import { LoginService } from 'src/app/core/services/login.service';
import { ShippingService } from 'src/app/core/services/shipping.service';

@Component({
  selector: 'app-cart-checkout',
  templateUrl: './cart-checkout.component.html',
  styleUrls: ['./cart-checkout.component.css']
})
export class CartCheckoutComponent implements OnInit, OnDestroy{
  
  private readonly _shoppingCartService = inject(CartService);
  private readonly _loginService = inject(LoginService);
  private readonly _shippingService = inject(ShippingService);
  
  private _idShoppingCart: number = 0;

  private shopCartChangedSubs?: Subscription;
  private shippingSubs?: Subscription;

  cartItems!: CartItem[];
  shopCart! : ShoppingCart;
  shippingPrice:number = 0;

  

  ngOnInit(): void {
    this._idShoppingCart = this._loginService.getCurrentShopCartId()!;
    
    this.setCartCheckOut();
    this.setShippingPrice();
  }
  
  private setShippingPrice(){
    this.shippingSubs = this._shippingService.getShippingPrice().subscribe(value =>{
      this.shippingPrice = value;
    })
  }

  private setCartCheckOut(){
    this.shopCartChangedSubs = this._shoppingCartService.getShopCartChanged().pipe(
      switchMap(value =>{
           return this._shoppingCartService.getShopCart(this._idShoppingCart);
 
      })
     ).subscribe( resp => {
       console.log(resp);
       this.shopCart = resp.data;
       this.cartItems = resp.data.cartItems;
     })
  }
  ngOnDestroy(): void {
    this.shopCartChangedSubs?.unsubscribe();
    this.shippingSubs?.unsubscribe();
  }
}
