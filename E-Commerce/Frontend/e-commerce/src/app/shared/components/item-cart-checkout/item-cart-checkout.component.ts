import { Component, Input, OnInit } from '@angular/core';
import { Image } from 'src/app/core/models/product/image';

@Component({
  selector: 'app-item-cart-checkout',
  templateUrl: './item-cart-checkout.component.html',
  styleUrls: ['./item-cart-checkout.component.css']
})
export class ItemCartCheckoutComponent implements OnInit{
  @Input() images:Image[] = [];
  @Input() title:string = "";
  @Input() price:number = 0;
  
  imgScr:string = "";
  ngOnInit(): void {
    this.setImage();
  }

  setImage(){
    this.imgScr = this.images[0] != null ? this.images[0].name : '../../../../assets/images/default.png';
  }
}
