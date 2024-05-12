import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product/product';
import { CustomService } from './customService';
import { Response } from '../models/response';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends CustomService{

  private readonly _http = inject(HttpClient);

  constructor( ) {
    super();
   }

  getAll():Observable<Response>{
    return this._http.get<Response>(`${this.apiPath}/product`);
  }

  getById(id:number):Observable<Response>{
    return this._http.get<Response>( `${this.apiPath}/product/${id}`);
  }
}
