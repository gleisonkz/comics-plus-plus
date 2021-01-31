import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { LoginFormComponent } from '@auth/presentation/components';
import { NotificationService } from '@core/services';
import { AuthenticationService } from '@core/services/authentication.service';
import { fadeInOut } from '@shared/animations/fade-in-out';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  animations: [fadeInOut]
})
export class LoginComponent {
  @ViewChild(LoginFormComponent, { static: true })
  loginComponent: LoginFormComponent;

  constructor(
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  login() {
    this.loginComponent.form.valid &&
      this.authenticationService
        .postLoginUser(this.loginComponent.form.value)
        .subscribe((c) => {
          this.notificationService.showMessage('Login efetuado com sucesso');
          this.router.navigate(['/']);
        });
  }
}
