import { AbstractControl } from '@angular/forms';

export const ArrayValidation = [
  {
    key: 'required',
    value: (control: AbstractControl) => 'campo<strong> obrigatório</strong>'
  },
  {
    key: 'email',
    value: (control: AbstractControl) => 'email<strong> inválido</strong>'
  },
  {
    key: 'minlength',
    value: (control: AbstractControl) =>
      `mínimo de <strong>${control.errors.minlength.requiredLength} caracteres</strong>`
  },
  {
    key: 'maxlength',
    value: (control: AbstractControl) =>
      `máximo de <strong>${control.errors.maxlength.requiredLength} caracteres</strong>`
  },
  {
    key: 'pattern',
    value: (control: AbstractControl) => `<strong>caracteres</strong> inválidos`
  },
  {
    key: 'emailsNotMatch',
    value: (control: AbstractControl) =>
      `os emails <strong>estão diferentes!</strong>`
  },
  {
    key: 'passwordsNotMatch',
    value: (control: AbstractControl) =>
      `as senhas  <strong>estão diferentes!</strong>`
  },
  {
    key: 'postalCodeError',
    value: (control: AbstractControl) => control.errors.postalCodeError
  },
  {
    key: 'lowerCaseCharacter',
    value: (control: AbstractControl) => control.errors.lowerCaseCharacter
  },
  {
    key: 'pascalCaseCharacter',
    value: (control: AbstractControl) => control.errors.pascalCaseCharacter
  },

  {
    key: 'specialCharacter',
    value: (control: AbstractControl) => control.errors.specialCharacter
  }
];
