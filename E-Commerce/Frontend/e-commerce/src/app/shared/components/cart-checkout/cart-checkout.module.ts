import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartCheckoutComponent } from './cart-checkout.component';
import { ItemCartCheckoutModule } from '../item-cart-checkout/item-cart-checkout.module';



@NgModule({
  declarations: [
    CartCheckoutComponent
  ],
  imports: [
    CommonModule,
    ItemCartCheckoutModule
  ],
  exports:[
    CartCheckoutComponent,
  ]
})
export class CartCheckoutModule { }
