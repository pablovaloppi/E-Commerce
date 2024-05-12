import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemCartComponent } from './item-cart.component';
import { QuantityButtonsModule } from '../quantity-buttons/quantity-buttons.module';



@NgModule({
  declarations: [
    ItemCartComponent
  ],
  imports: [
    CommonModule,
    QuantityButtonsModule,
  ],
  exports:[
    ItemCartComponent
  ]
})
export class ItemCartModule { }
