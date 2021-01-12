import {
  AfterContentInit,
  Directive,
  ElementRef,
  Input,
  OnDestroy
} from '@angular/core';
import {
  AbstractControl,
  ControlContainer,
  FormControl,
  FormGroup
} from '@angular/forms';
import { ArrayValidation } from '@shared/constants/array-validation';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[cmsShowValidation]'
})
export class ShowValidationDirective implements AfterContentInit, OnDestroy {
  @Input('cmsShowValidation') controlName: string;

  private subscriptions: Subscription[] = [];

  constructor(
    private elementRef: ElementRef,
    private parent: ControlContainer
  ) {}

  ngAfterContentInit(): void {
    const group = this.parent.control as FormGroup;
    const control = group.controls[this.controlName] as FormControl;
    const handleState = () => {
      const errorMessage = this.checkValidations(control);
      const errorMessageParent = this.checkValidations(group);
      const error = errorMessage || errorMessageParent;
      this.setInnerHTML(error);
    };

    this.subscriptions.push(
      control.statusChanges.subscribe(() => handleState())
    );

    handleState();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((subscription) => subscription.unsubscribe());
  }

  private setInnerHTML(html: string) {
    this.elementRef.nativeElement.innerHTML = html;
  }

  private checkValidations(control: AbstractControl): string {
    return (
      ArrayValidation.find((c) => control.hasError(c.key))?.value(control) || ''
    );
  }
}
