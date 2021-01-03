import {
  AbstractControl,
  FormControl,
  ValidationErrors,
  Validators
} from '@angular/forms';

export class CustomValidators extends Validators {
  static minOneLowerCaseCharacter(
    control: FormControl
  ): ValidationErrors | null {
    if (CustomValidators.controlHasValue(control)) {
      const hasLowerCaseCharacter = /[a-z]/g.test(control.value);

      return hasLowerCaseCharacter
        ? null
        : {
            lowerCaseCharacter:
              'é necessário pelo menos <strong>1 letra minúscula</strong>'
          };
    } else {
      return null;
    }
  }

  static minOnePascalCaseCharacter(
    control: FormControl
  ): ValidationErrors | null {
    if (CustomValidators.controlHasValue(control)) {
      const hasPascalCaseCharacter = /[A-Z]/g.test(control.value);

      return hasPascalCaseCharacter
        ? null
        : {
            pascalCaseCharacter:
              'é necessário pelo menos <strong>1 letra maiúscula</strong>'
          };
    } else {
      return null;
    }
  }

  static minOneSpecialCharacter(control: FormControl): ValidationErrors | null {
    if (CustomValidators.controlHasValue(control)) {
      const hasSpecialCharacter = /[`´!¨@#$%^&*ª°º§()_+\-=\[\]{};':"\\|,.<>\/?~]/g.test(
        control.value
      );

      return hasSpecialCharacter
        ? null
        : {
            specialCharacter:
              'é necessário pelo menos <strong>1 carácter especial</strong>'
          };
    } else {
      return null;
    }
  }

  static matchValues(
    matchTo: string
  ): (abstractControl: AbstractControl) => ValidationErrors | null {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control.parent)
        throw new Error(
          'É necessário que o controle esteja associado a um form group'
        );

      return control.value === control.parent.controls[matchTo].value
        ? null
        : { passwordsNotMatch: true };
    };
  }

  private static controlHasValue(control: FormControl): boolean {
    return control.value && control.value.length > 0;
  }
}
