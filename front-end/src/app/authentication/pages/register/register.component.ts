import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterUser } from '@auth/models';
import { AuthenticationService } from '@core/services/authentication.service';
import { CustomValidators } from '@shared/classes/custom-validators';

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup(
      {
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
          CustomValidators.minOneLowerCaseCharacter,
          CustomValidators.minOnePascalCaseCharacter,
          CustomValidators.minOneSpecialCharacter
        ]),
        passwordCheck: new FormControl('', [Validators.required])
      },
      { validators: RegisterComponent.matchPassword }
    );
  }

  static matchPassword(formGroup: AbstractControl): { [key: string]: boolean } {
    const password = formGroup.get('password');
    const passwordCheck = formGroup.get('passwordCheck');

    if (!password || !passwordCheck || password.value === passwordCheck.value) {
      return null;
    }

    return { passwordsNotMatch: true };
  }

  register(user: RegisterUser) {
    if (this.form.invalid) return;
    this.authenticationService.postRegisterUser(user).subscribe(() => {
      this.router.navigate(['authentication/register/done']);
    });
  }
}
