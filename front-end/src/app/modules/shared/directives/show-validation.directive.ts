import {
  AfterContentInit,
  Directive,
  ElementRef,
  Input,
  OnDestroy,
} from '@angular/core';
import {
  AbstractControl,
  ControlContainer,
  FormControl,
  FormGroup,
} from '@angular/forms';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[cmsShowValidation]',
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

export const ArrayValidation = [
  {
    key: 'required',
    value: (control: AbstractControl) => 'campo<strong> obrigatório</strong>',
  },
  {
    key: 'email',
    value: (control: AbstractControl) => 'email<strong> inválido</strong>',
  },
  {
    key: 'minlength',
    value: (control: AbstractControl) =>
      `mínimo de <strong>${control.errors.minlength.requiredLength} caracteres</strong>`,
  },
  {
    key: 'maxlength',
    value: (control: AbstractControl) =>
      `máximo de <strong>${control.errors.maxlength.requiredLength} caracteres</strong>`,
  },
  {
    key: 'pattern',
    value: (control: AbstractControl) =>
      `<strong>caracteres</strong> inválidos`,
  },
  {
    key: 'emailsNotMatch',
    value: (control: AbstractControl) =>
      `os emails <strong>estão diferentes!</strong>`,
  },
  {
    key: 'postalCodeError',
    value: (control: AbstractControl) => control.errors.postalCodeError,
  },
];
