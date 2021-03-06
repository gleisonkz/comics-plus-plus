import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from '@auth/models';
import { NotificationService } from '@core/services';
import { AuthenticationService } from '@core/services/authentication.service';
import { fadeInOut } from '@shared/animations/fade-in-out';
import { CustomValidators } from '../../../shared/classes/custom-validators';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  animations: [fadeInOut]
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  constructor(
    private authenticationService: AuthenticationService,
    private notificationService: NotificationService,
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
      ])
    });
  }

  login(user: LoginUser) {
    if (this.form.invalid) return;
    this.authenticationService.postLoginUser(user).subscribe((c) => {
      this.notificationService.showMessage('Login efetuado com sucesso');
      this.router.navigate(['/']);
    });
  }
}
