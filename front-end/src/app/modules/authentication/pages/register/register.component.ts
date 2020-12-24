import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationService } from '../../../../services/notification.service';
import { RegisterUser } from '../../models/register-user.model';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  constructor(
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup(
      {
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
        passwordCheck: new FormControl('', [
          Validators.required,
          Validators.minLength(8),
        ]),
      },
      { validators: RegisterComponent.matchPassword }
    );
  }

  static matchPassword(formGroup: AbstractControl): { [key: string]: boolean } {
    const password = formGroup.get('password');
    const passwordCheck = formGroup.get('passwordCheck');

    if (!password || !passwordCheck || password.value === passwordCheck.value) {
      return undefined;
    }

    return { passwordsNotMatch: true };
  }

  register(user: RegisterUser) {
    if (this.form.invalid) return;
    this.authenticationService.postRegisterUser(user).subscribe((c) => {
      this.router.navigate(['authentication/register/done']);
    });
  }
}
