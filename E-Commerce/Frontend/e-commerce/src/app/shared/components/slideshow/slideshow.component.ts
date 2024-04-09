import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component } from '@angular/core';

@Component({
  selector: 'app-slideshow',
  templateUrl: './slideshow.component.html',
  styleUrls: ['./slideshow.component.css'],
  animations:[
    trigger('animacionTranslacion', [
      state('inactivo', style({
        transform: 'translateX(0)' /* Sin traslación inicial */
      })),
      state('activo', style({
        transform: 'translateX(-100%)' /* Traslación hacia la izquierda, tres veces */
      })),
      transition('inactivo <=> activo', animate('1s ease-in')),
    ])
  ]
})
export class SlideshowComponent {
  
  estadoAnimacion: string = 'inactivo';

  ejecutarAnimacion() {
    this.estadoAnimacion = this.estadoAnimacion == 'activo' ? 'inactivo' : 'activo';
    this.estadoAnimacion ='activo'
    console.log(this.estadoAnimacion);
  }
}
