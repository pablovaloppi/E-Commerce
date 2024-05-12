import { Directive, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[less]'
})
export class LessDirective {

  @Input() less!:number;
  
  @HostListener('input', ['$event'])
  onInput(event:any){
    if(event.target.value > this.less){
      event.target.value = this.less
    }
  }
}
