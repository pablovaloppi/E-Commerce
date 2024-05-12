import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuantityButtonsComponent } from './quantity-buttons.component';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    QuantityButtonsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  exports:[
    QuantityButtonsComponent
  ]
})
export class QuantityButtonsModule { }
