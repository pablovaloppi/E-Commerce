import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { userGuard } from './core/guards/user.guard';
import { SalesModule } from './pages/sales/sales.module';

const routes: Routes = [
  {path: 'home', component:HomeComponent},
  {path: 'product', loadChildren: () => import('./pages/product/product.module').then( m=> m.ProductModule) },
  {path: 'login', loadChildren:() => import('./pages/login/login.module').then( m => m.LoginModule), canActivate: [userGuard]},
  {path: 'shop', loadChildren:() => import('./pages/shop/shop.module').then(m => m.ShopModule )},
  {path: 'checkout', loadChildren:() => import('./pages/checkout/checkout.module').then(m => m.CheckoutModule)},
  {path: 'sales', loadChildren:() => import('./pages/sales/sales.module').then(m => m.SalesModule)},
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: '**', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
