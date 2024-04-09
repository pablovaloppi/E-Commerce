import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { MenuPrincipalModule } from 'src/app/shared/components/menu-principal/menu-principal.module';
import { ProductCardModule } from 'src/app/shared/components/product-card/product-card.module';
import { SlideshowModule } from 'src/app/shared/components/slideshow/slideshow.module';



@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    MenuPrincipalModule,
    ProductCardModule,
    SlideshowModule
  ],
  exports:[
    HomeComponent
  ]
})
export class HomeModule { }
