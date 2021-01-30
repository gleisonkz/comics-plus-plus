import {
  Component,
  EventEmitter,
  OnDestroy,
  OnInit,
  Output
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterUser } from '@auth/models';
import { CustomValidators } from '@shared/classes/custom-validators';
import { Subscription } from 'rxjs';

@Component({
  selector: 'register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit, OnDestroy {
  form: FormGroup;
  private subscription = new Subscription();
  @Output() registerEvent = new EventEmitter<RegisterUser>();

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
      ]),
      passwordCheck: new FormControl('', [
        Validators.required,
        CustomValidators.matchValues('password')
      ])
    });

    this.subscription.add(
      this.form.controls.password.valueChanges.subscribe(() => {
        this.form.controls.passwordCheck.updateValueAndValidity();
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  register(user: RegisterUser) {
    this.form.valid && this.registerEvent.emit(user);
  }
}
