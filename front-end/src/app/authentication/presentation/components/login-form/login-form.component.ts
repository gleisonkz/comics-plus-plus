import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidators } from '@shared/classes/custom-validators';

@Component({
  selector: 'login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  form: FormGroup;
  @Output() loginEvent = new EventEmitter<void>();
  constructor() {}

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

  login() {
    this.form.valid && this.loginEvent.emit();
  }
}
