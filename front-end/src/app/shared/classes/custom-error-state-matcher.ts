import { FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class CustomErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    const invalidControl = !!(
      control &&
      control.invalid &&
      (control.untouched || control.dirty || control.touched || isSubmitted)
    );
    return invalidControl;
  }
}
