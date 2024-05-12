import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShippingMethodComponent } from './shipping-method.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShippingMethodComponent
  ],
  imports: [
    CommonModule,
    MatExpansionModule,
    ReactiveFormsModule,
  ],
  exports:[
    ShippingMethodComponent
  ]
})
export class ShippingMethodModule { }
