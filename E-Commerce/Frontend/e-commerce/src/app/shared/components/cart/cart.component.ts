import {
  ChangeDetectionStrategy,
  Component,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
  inject,
} from '@angular/core';
import { ItemCartComponent } from '../item-cart/item-cart.component';
import { ItemCartModule } from '../item-cart/item-cart.module';
import { MatDialogRef } from '@angular/material/dialog';
import { Product } from 'src/app/core/models/product/product';
import { CartService } from 'src/app/core/services/cart.service';
import { LoginService } from 'src/app/core/services/login.service';
import { ShoppingCart } from 'src/app/core/models/shoppingCart/shoppingCart';
import { CommonModule } from '@angular/common';
import { ShoppingCartUpdate } from '../../../core/models/shoppingCart/shoppingCartUpdate';
import { QuantityButtonsService } from '../../communicationService/quantity-buttons.service';
import { Subscription, find } from 'rxjs';
import { CartItem } from 'src/app/core/models/cartItem/cartItem';
import { CartItemUpdate } from 'src/app/core/models/cartItem/cartItemUpdate';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, ItemCartModule, RouterModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit, OnDestroy {
  private readonly _dialogRef = inject(MatDialogRef<CartComponent>);
  private readonly _cartService = inject(CartService);
  private readonly _loginService = inject(LoginService);
  private readonly _quantityButtonService = inject(QuantityButtonsService);

  private shopCartId?: number;
  private userId?:number;
  private _quantitySubscription?: Subscription;
  private _shoppingCartChange: boolean = false;

  shopCartView?: ShoppingCart;


  ngOnInit(): void {
    this.shopCartId = this._loginService.getCurrentShopCartId()!;
    this.userId = this._loginService.getCurrentIdLogued()!;
    this.setShopCart(this.shopCartId);
  }

  ngOnDestroy(): void {
    this._quantitySubscription?.unsubscribe();
  }

  onCloseCart() {
    this._dialogRef.close();
    this.updateShopCart();
  }

  onChangePrice(event: any) {
    this.setTotalPrice(event.price);
    this.changeQuantityItem(event.position);
  }

  onDeleteItem(event: number) {
    console.log(this.shopCartView);
    
    this.setTotalPrice(-this.removeItem(event)!.totalPrice);

     this._cartService.deleteItem(this.shopCartId!, event).subscribe((resp) => {
           this.shopCartView = resp.data;
           console.log(resp.data);
           this._cartService.setQuantityItem(resp.data.cartItems.length);
           if(resp.data.cartItems.length == 0){
            this._cartService.setAreItems(false);
           }
           this._cartService.setShopCartChanged(true);
        });

  }


  private removeItem(id:number):CartItem{
    let elementDelete!:CartItem;

    this.shopCartView?.cartItems.splice(this.shopCartView?.cartItems.findIndex(item =>{elementDelete= item; item.id === id}),1);
   
    return elementDelete;
  }
  // Se va a actualizar todo el shop solamente cuando se cierra la ventana del mismo o cuando se le de en comprar
  private updateShopCart() {
    if(this._shoppingCartChange){
      console.log(this.getShopCartForUpdate());

     this._cartService.updateShopCart(this.getShopCartForUpdate()).subscribe(resp => {
       console.log("Se Actualizo correctamente.");
         this._shoppingCartChange = false;  
        this._cartService.setShopCartChanged(true);
     })
    }
    
  }

  private changeQuantityItem(position: number) {
    this._quantitySubscription = this._quantityButtonService.getQuantity(position)?.subscribe( value =>{
      this.shopCartView!.cartItems[position].quantity = value;
    });

    this._shoppingCartChange = true;
  }

  private setShopCart(shopCartId: number) {
    this._cartService.getShopCart(shopCartId).subscribe((resp) => {
      this.shopCartView = resp.data;
      this.shopCartView?.cartItems.forEach( (item, index) => { this._quantityButtonService.setQuantity(index, item.quantity) } );
      this.shopCartView?.cartItems.forEach( (item, index) => { this._quantityButtonService.setStockAmount(index, item.product.amount) } );

      this._cartService.setQuantityItem(resp.data.cartItems.length)
    });
  }
  private getShopCartForUpdate():ShoppingCartUpdate{
   return{ 
      id:this.shopCartId!, 
      userId: this.userId!,
      total: this.shopCartView!.total,
      cartItems: this.CreateCartItemFormUpdate(this.shopCartView!.cartItems)
    };
  }
  private CreateCartItemFormUpdate( cartItems:CartItem[]):CartItemUpdate[]{ 
    return cartItems.map( item =>({
      id: item.id,
      quantity: item.quantity,
      totalPrice: item.totalPrice,
      productId: item.product.id
    }));  
  }
  private setTotalPrice(price: number) {
    this.shopCartView!.total += price;
  }
}


