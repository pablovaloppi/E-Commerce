import { NgModule, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuPrincipalComponent } from './menu-principal.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [MenuPrincipalComponent],
  imports: [CommonModule, MatTooltipModule, RouterModule, MatDialogModule],
  exports: [MenuPrincipalComponent],
})
export class MenuPrincipalModule {}
