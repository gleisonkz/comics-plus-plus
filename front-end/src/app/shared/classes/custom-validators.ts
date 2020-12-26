import { FormControl, Validators } from '@angular/forms';

export class CustomValidators extends Validators {
  static minOneLowerCaseCharacter(control: FormControl) {
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

  static minOnePascalCaseCharacter(control: FormControl) {
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

  static minOneSpecialCharacter(control: FormControl) {
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

  private static controlHasValue(control: FormControl): boolean {
    return control.value && control.value.length > 0;
  }
}
