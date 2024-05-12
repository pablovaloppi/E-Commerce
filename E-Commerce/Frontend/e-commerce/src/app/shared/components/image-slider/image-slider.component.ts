
import { Component, Input, OnInit } from '@angular/core';
import { Image } from 'src/app/core/models/product/image';

@Component({
  selector: 'image-slider',
  templateUrl: './image-slider.component.html',
  styleUrls: ['./image-slider.component.css'],

 })
export class ImageSliderComponent implements OnInit{

  @Input() images:Image[] = [];
  imgScr:string ='';
  imgPosition:number = 0;
        
  ngOnInit(): void {
    this.imgScr = this.images[0].name;
  }

  next() {
    this.imgScr = this.images[this.clampLengtImgaes( this.imgPosition += 1)].name;
  }

  previous() {
    this.imgScr = this.images[this.clampLengtImgaes( this.imgPosition -= 1)].name;
  }

  private clampLengtImgaes(value:number):number{
    if(value > this.images.length -1)
      return this.imgPosition = this.images.length - 1;
    else if( value < 0)
      return this.imgPosition = 0;

    return value;
  }
}
