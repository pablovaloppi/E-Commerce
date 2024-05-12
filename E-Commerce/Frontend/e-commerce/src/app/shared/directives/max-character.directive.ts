import { Directive, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[maxCharacter]'
})
export class MaxCharacterDirective {

  @Input() maxCharacter!: number;

  @HostListener('input', ['$event.target'])
  onInput(input: HTMLInputElement){
    if(input.value.length > this.maxCharacter!){
      input.value = input.value.slice(0, this.maxCharacter);
    }
  }
}
 