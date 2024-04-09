import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuPrincipalComponent } from './menu-principal.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [MenuPrincipalComponent],
  imports: [CommonModule, MatTooltipModule, RouterModule],
  exports: [MenuPrincipalComponent],
})
export class MenuPrincipalModule {}
