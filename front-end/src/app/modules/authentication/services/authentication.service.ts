import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginUser } from '../models/login-user.model';
import { RegisterUser } from '../models/register-user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(private http: HttpClient) {}

  postRegisterUser(user: RegisterUser): Observable<RegisterUser> {
    return this.http.post<RegisterUser>(
      `${environment.apiURL}/authentication/register`,
      user
    );
  }
  postLoginUser(user: LoginUser): Observable<LoginUser> {
    return this.http.post<LoginUser>(
      `${environment.apiURL}/authentication/login`,
      user
    );
  }
}
