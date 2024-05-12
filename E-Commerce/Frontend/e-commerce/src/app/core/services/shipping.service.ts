import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { ShippingMethod } from '../models/shippingMethod';

@Injectable({
  providedIn: 'root'
})
export class ShippingService {

  private _shipping$ = new Subject<ShippingMethod>();
  private _shippinPrice$ = new BehaviorSubject<number>(0);

  constructor() { }

  setShipping(shipping:ShippingMethod){
    this._shipping$.next(shipping);
  }
  
  getShipping(): Observable<ShippingMethod>{
    return this._shipping$.asObservable();
  }

  setShippingPrice(value: number){
    this._shippinPrice$.next(value);
  }

  getShippingPrice():Observable<number>{
    return this._shippinPrice$.asObservable();
  }
}
