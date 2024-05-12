import { Directive, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[onlyLetter]'
})
export class OnlyLetterDirective {

  @HostListener('input', ['$event'])
  onInputChange(event: any) {
    event.target.value = event.target.value.replace(/[^a-zA-Z\s]/g, '');    
  }
}
  