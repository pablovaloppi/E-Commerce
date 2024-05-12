import { Component, EventEmitter, Input, OnInit, Output, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Image } from 'src/app/core/models/product/image';
import { QuantityButtonsService } from '../../communicationService/quantity-buttons.service';

@Component({
  selector: 'app-item-cart',
  templateUrl: './item-cart.component.html',
  styleUrls: ['./item-cart.component.css']
})
export class ItemCartComponent implements OnInit{
  @Input() stockAmount:number = 1;
  //@Input() quantity:number = 1;
  @Input() title:string = '';
  @Input() imagenScr: Image[] = [];
  @Input() price:number= 1;
  @Input() itemId = 0;
  @Input() itemPosition = 0;

  @Output() clickDelete = new EventEmitter<number>();
  @Output() changePrice = new EventEmitter<any>();

  private _quantityButtonService = inject(QuantityButtonsService);
  
  totalPrice:number = 1;
  unitPrice: number = 1;
  totalAmount:number = this.stockAmount;
  imgScr:string = '';
  private lastPrice = 1;
  private quantity = 1;

  ngOnInit(): void {
    
    this.initPrice(); 
    this.setImage();
    
  }
  setPrice(){
    this.lastPrice = this.totalPrice;
    this._quantityButtonService.getQuantity(this.itemPosition)?.subscribe(value => {
      this.totalPrice = this.unitPrice * value;
    })
    
    // Si el lastPrice es mayor que total price quiere decir que aprete el boton de agregar producto
    // Por lo tanto debo enviar para sumar el precio de un producto, en caso contrario envio uno resta
    this.lastPrice < this.totalPrice ? this.changePrice.emit({price:this.unitPrice, position:this.itemPosition}) 
                                    : this.changePrice.emit({price:-this.unitPrice, position:this.itemPosition});     
  }

  private initPrice(){
    this._quantityButtonService.getQuantity(this.itemPosition)?.subscribe(value => {
      this.quantity = value;
      
      this.unitPrice = this.price / this.quantity;
      this.totalPrice = this.unitPrice * this.quantity;
    });
  }

  setImage(){
    this.imgScr = this.imagenScr[0] != null ? this.imagenScr[0].name : '../../../../assets/images/default.png';
  }

  onDelete(){
    this.clickDelete.emit(this.itemId);
  }
}
