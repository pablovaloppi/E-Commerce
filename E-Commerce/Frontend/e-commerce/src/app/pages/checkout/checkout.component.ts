import { Component } from '@angular/core';
import { Shipping } from 'src/app/core/models/shipping';
import { Withdraw } from 'src/app/core/models/withdraw';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent {
  isInShippig = false;
  isInPayment = true;

  shippingMethod!: Shipping | Withdraw;

  onBackShipping() {
    if (this.isInPayment) {
      this.changeStates();
    }
  }

  onGetShipping(event: Shipping | Withdraw){
    console.log(event);
    this.shippingMethod = event;
    this.changeStates();
  }

  private changeStates(){
    this.isInPayment = !this.isInPayment;
    this.isInShippig = !this.isInShippig;
  }
}
