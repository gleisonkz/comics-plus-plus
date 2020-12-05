import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotificationService } from '../../../shared/services/notification.service';
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
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.form = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
      passwordCheck: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
  }

  register(user: RegisterUser) {
    if (this.form.invalid) return;
    this.authenticationService.postRegisterUser(user).subscribe((c) => {
      this.notificationService.showMessage('Usuário cadastrado com sucesso');
    });
  }
}