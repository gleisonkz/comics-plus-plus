import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {
  LoginFormComponent,
  RegisterFormComponent
} from '@auth/presentation/components';
import {
  LoginComponent,
  RegisterComponent,
  RegisterDoneComponent
} from '@auth/presentation/pages';
import { SharedModule } from '@shared/shared.module';
import { AuthenticationRoutingModule } from './authentication-routing.module';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    RegisterDoneComponent,
    RegisterFormComponent,
    LoginFormComponent
  ],
  imports: [
    AuthenticationRoutingModule,
    CommonModule,
    SharedModule,
    MatCardModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule
  ]
})
export class AuthenticationModule {}
