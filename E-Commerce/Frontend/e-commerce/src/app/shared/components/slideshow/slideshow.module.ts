import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SlideshowComponent } from './slideshow.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
  declarations: [
    SlideshowComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule
  ],
  exports:[
    SlideshowComponent
  ]
})
export class SlideshowModule { }
