import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { mergeMap, tap } from 'rxjs';
import { CartItemCreation } from 'src/app/core/models/cartItem/cartItemCreation';
import { Product } from 'src/app/core/models/product/product';
import { CartService } from 'src/app/core/services/cart.service';
import { LoginService } from 'src/app/core/services/login.service';
import { ProductService } from 'src/app/core/services/product.service';
import { QuantityButtonsService } from 'src/app/shared/communicationService/quantity-buttons.service';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit{
  private _route = inject(ActivatedRoute);
  private _productService = inject(ProductService);
  private _quantityButtonService = inject(QuantityButtonsService)
  private _shopCartService = inject(CartService);
  private _loginService = inject(LoginService);
  

  product!: Product;
  idProduct: number = 0;
  quantity:number = 1;
  shopCartId:number = 0;

  ngOnInit(): void {
   this._route.params.subscribe((value:Params) =>{
      this.idProduct = value['id'];   
   })
   this.setProduct();

   this.shopCartId = this._loginService.getCurrentShopCartId()!;
  }

  
  onAddToCart(){
    this.getQuantityButton();
    let cartItem: CartItemCreation = {productId: this.product.id, quantity:this.quantity, shoppingCartId:this.shopCartId};
    
    // console.log(cartItem);
    // this._shopCartService.addNewItem(cartItem).subscribe(resp =>{
    //   console.log(resp);
    // })
    console.log(cartItem);
    this._shopCartService.addNewItem(cartItem).pipe().subscribe( resp =>{
      console.log(resp.data);
      this._shopCartService.setQuantityItem(resp.data.cartItems.length);
      this._shopCartService.setAreItems(true);
    })
  }
  
  private setProduct(){
    this._productService.getById(this.idProduct).subscribe( resp =>{
      this.product = resp.data;
      this._quantityButtonService.setStockAmount(this.product.id, this.product.amount);
    })
  }
  private getQuantityButton(){
    this._quantityButtonService.getQuantity(this.product.id)?.subscribe((value:number) =>{
      this.quantity = value;
    })
  }
}
