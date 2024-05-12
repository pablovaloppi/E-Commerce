import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemCartCheckoutComponent } from './item-cart-checkout.component';



@NgModule({
  declarations: [
    ItemCartCheckoutComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ItemCartCheckoutComponent
  ]
})
export class ItemCartCheckoutModule { }
