import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  LoginComponent,
  RegisterComponent,
  RegisterDoneComponent
} from '@auth/pages';

const routes: Routes = [
  { path: '', redirectTo: 'login' },
  { path: 'login', component: LoginComponent },
  {
    path: 'register',
    component: RegisterComponent
  },
  { path: 'register/done', component: RegisterDoneComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule {}
