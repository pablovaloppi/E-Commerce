import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentMethodComponent } from './payment-method.component';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MaxCharacterDirective } from '../../directives/max-character.directive';
import { RouterModule } from '@angular/router';
import { OnlyLetterDirective } from '../../directives/only-letter.directive';
import { LessDirective } from '../../directives/less.directive';

@NgModule({
  declarations: [
    PaymentMethodComponent,
    MaxCharacterDirective,
    OnlyLetterDirective,
    LessDirective,
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports:[
    PaymentMethodComponent
  ]
})
export class PaymentMethodModule { }
