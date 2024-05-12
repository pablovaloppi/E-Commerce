import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CheckoutRoutingModule } from './checkout-routing.module';
import { CheckoutComponent } from './checkout.component';
import { ShippingMethodModule } from 'src/app/shared/components/shipping-method/shipping-method.module';
import { PaymentMethodModule } from 'src/app/shared/components/payment-method/payment-method.module';
import { CartCheckoutModule } from 'src/app/shared/components/cart-checkout/cart-checkout.module';

@NgModule({
  declarations: [
    CheckoutComponent
  ],
  imports: [
    CommonModule,
    CheckoutRoutingModule,
    ShippingMethodModule,
    PaymentMethodModule,
    CartCheckoutModule,
  ],
  exports:[
    CheckoutComponent
  ]
})
export class CheckoutModule { }
