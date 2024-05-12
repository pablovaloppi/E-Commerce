import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuantityButtonsService {

  // private _$quantity = new BehaviorSubject(1);
  // constructor() { }

  // getQuantity():Observable<number>{
  //   return this._$quantity.asObservable().pipe(take(1));
  // }

  // setQuantity(value:number){
  //   this._$quantity.next(value);
  // }

  private quantitySources: Map<number, BehaviorSubject<number>> = new Map();
  private stockAmount: Map<number, BehaviorSubject<number>> = new Map();

  setQuantity(itemId:number, newQuantity:number){
    if(!this.quantitySources.has(itemId)){
      this.quantitySources.set(itemId, new BehaviorSubject<number>(1));
    }
    this.quantitySources.get(itemId)?.next(newQuantity);
  }

  getQuantity(itemId: number){
    if(!this.quantitySources.has(itemId)){
      this.quantitySources.set(itemId, new BehaviorSubject<number>(1));
    }
    return this.quantitySources.get(itemId)?.asObservable().pipe(take(1));
  }

  setStockAmount(itemId:number, newStock:number){
    if(!this.stockAmount.has(itemId)){
      this.stockAmount.set(itemId, new BehaviorSubject<number>(1));
    }
    this.stockAmount.get(itemId)?.next(newStock);
  }

  getStockAmount(itemId: number){
    if(!this.stockAmount.has(itemId)){
      this.stockAmount.set(itemId, new BehaviorSubject<number>(1));
    }
    return this.stockAmount.get(itemId)?.asObservable().pipe(take(1));
  }
}
