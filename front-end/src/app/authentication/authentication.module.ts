import { NgModule } from '@angular/core';
import {
  LoginComponent,
  RegisterComponent,
  RegisterDoneComponent
} from '@auth/pages';
import { SharedModule } from '@shared/shared.module';
import { AuthenticationRoutingModule } from './authentication-routing.module';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, RegisterDoneComponent],
  imports: [AuthenticationRoutingModule, SharedModule]
})
export class AuthenticationModule {}
