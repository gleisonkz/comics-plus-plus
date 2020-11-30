import { Directive, ElementRef, HostListener, OnInit } from '@angular/core';

@Directive({
  selector: '[cmsFormatNumber]',
})
export class FormatNumberDirective implements OnInit {
  constructor(private element: ElementRef) {}
  ngOnInit(): void {
    console.log('init');
  }

  @HostListener('keyup') onkeydown() {
    let value = this.element.nativeElement.value;
    console.log('directive', value === null);
    value = value.split('0').join('');
  }
}
