import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent {
  @Input() title:string = "Title - Product";
  @Input() price:number = 30;
  @Input() imageSrc:string = '../../../../assets/images/default.png';
  @Input() leftLinkText:string = 'Buy Now';
  @Input() leftLinkPath:string = '';
  @Input() rightLinkText:string = 'See More';
  @Input() rightLinkPath:string = '';

}
