import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalesRoutingModule } from './sales-routing.module';
import { ConfirmComponent } from './confirm/confirm.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    ConfirmComponent
  ],
  imports: [
    CommonModule,
    SalesRoutingModule,
    RouterModule
  ]
})
export class SalesModule { }
