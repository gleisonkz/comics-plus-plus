import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterFormComponent } from '@auth/components';
import { AuthenticationService } from '@core/services/authentication.service';
import { fadeInOut } from '@shared/animations/fade-in-out';

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  animations: [fadeInOut]
})
export class RegisterComponent {
  constructor(
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  @ViewChild(RegisterFormComponent, { static: true })
  registerForm: RegisterFormComponent;

  register() {
    this.registerForm.form.valid &&
      this.authenticationService
        .postRegisterUser(this.registerForm.form.value)
        .subscribe(() => {
          this.router.navigate(['authentication/register/done']);
        });
  }
}
