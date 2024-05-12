import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { ProductRoutingModule } from './product-routing.module';
import { QuantityButtonsModule } from 'src/app/shared/components/quantity-buttons/quantity-buttons.module';



@NgModule({
  declarations: [
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule,
    QuantityButtonsModule,
  ]
})
export class ProductModule { }
