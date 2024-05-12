import { Injectable, inject } from '@angular/core';
import { CustomService } from './customService';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { Response } from '../models/response';
import { HttpClient } from '@angular/common/http';
import { CartItemCreation } from '../models/cartItem/cartItemCreation';
import { ShoppingCartUpdate } from '../models/shoppingCart/shoppingCartUpdate';

@Injectable({
  providedIn: 'root',
})
export class CartService extends CustomService {
  private readonly _http = inject(HttpClient);
  private readonly _url = `${this.apiPath}/cart`;

  private _quantityItems$ = new BehaviorSubject<number>(0);
  private _areItems$ = new BehaviorSubject<boolean>(false);
  private _shopCartChanged$ = new BehaviorSubject<boolean>(true);

  constructor() {
    super();
  }

  getShopCart(idShopCart: number): Observable<Response> {
    return this._http.get<Response>(`${this._url}/${idShopCart}`);
  }

  addNewItem(cartItem: CartItemCreation): Observable<Response>{
    return this._http.post<Response>(`${this._url}`, cartItem);
  }

  deleteItem(shopCartId:number, itemCartId:number): Observable<Response>{
    return this._http.delete<Response>(`${this._url}?shopCartId=${shopCartId}&itemCartId=${itemCartId}`);
  }

  updateShopCart(shopCart:ShoppingCartUpdate):Observable<Response>{
    this.setShopCartChanged(true);
    return this._http.put<Response>(`${this._url}`,shopCart);
  }

  setQuantityItem(value: number){
    this._quantityItems$.next(value);
  }

  getQuantityItems():Observable<number>{
    return this._quantityItems$.asObservable();
  }

  setAreItems(value:boolean){
    this._areItems$.next(value);
  }

  getAreItems():Observable<boolean>{
    return this._areItems$.asObservable();
  }

  setShopCartChanged(value:boolean){
    this._shopCartChanged$.next(true);
  }

  getShopCartChanged():Observable<boolean>{
    return this._shopCartChanged$.asObservable();
  }
}
