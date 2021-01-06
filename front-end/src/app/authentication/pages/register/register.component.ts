import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterUser } from '@auth/models';
import { AuthenticationService } from '@core/services/authentication.service';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { CustomValidators } from '@shared/classes/custom-validators';

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  animations: [fadeInOut]
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
        CustomValidators.minOneLowerCaseCharacter,
        CustomValidators.minOnePascalCaseCharacter,
        CustomValidators.minOneSpecialCharacter
      ]),
      passwordCheck: new FormControl('', [
        Validators.required,
        CustomValidators.matchValues('password')
      ])
    });

    this.form.controls.password.valueChanges.subscribe(() => {
      this.form.controls.passwordCheck.updateValueAndValidity();
    });
  }

  register(user: RegisterUser) {
    if (this.form.invalid) return;
    this.authenticationService.postRegisterUser(user).subscribe(() => {
      this.router.navigate(['authentication/register/done']);
    });
  }
}
