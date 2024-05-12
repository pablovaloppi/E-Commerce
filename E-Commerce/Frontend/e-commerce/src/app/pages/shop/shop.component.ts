import { Component, OnInit, inject } from '@angular/core';
import { Product } from 'src/app/core/models/product/product';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  private readonly _productService = inject(ProductService);

  products: Product[] = [];

  ngOnInit(): void {
    this._productService.getAll().subscribe( resp => {
      this.products = resp.data as Product[];
      console.log(resp.data);

    })
  }
  
}
