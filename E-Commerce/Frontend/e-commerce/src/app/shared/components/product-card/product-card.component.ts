import { Component, Input, OnInit } from '@angular/core';
import { Image } from 'src/app/core/models/product/image';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit{
  @Input() title:string = "Title - Product";
  @Input() price:number = 30;
  @Input() imageSrc: Image[] = [];
  @Input() productId: number = 0;
  // @Input() imageSrc:string = 
  @Input() leftLinkText:string = 'Buy Now';
 
  @Input() rightLinkText:string = 'See More';

  
  imgSrc:string = '../../../../assets/images/default.png';
  leftLinkPath:string = '';
  rightLinkPath:string = '';
  
  ngOnInit(): void {
    this.leftLinkPath = this.rightLinkPath =  `/product/${this.productId}`;
    this.imageSrc.length > 0 ? this.imgSrc = this.imageSrc[0].name : this.imgSrc = '../../../../assets/images/default.png';
  }
}
 