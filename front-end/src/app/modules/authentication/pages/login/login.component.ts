import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from 'src/app/modules/shared/services/notification.service';
import { LoginUser } from '../../models/login-user.model';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  constructor(
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }

  login(user: LoginUser) {
    console.log(user);

    if (this.form.invalid) return;
    this.authenticationService.postLoginUser(user).subscribe((c) => {
      this.notificationService.showMessage('Login efetuado com sucesso');
    });
  }
}
