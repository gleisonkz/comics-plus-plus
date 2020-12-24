import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { NotificationService } from '../../../services/notification.service';
import { LoginUser } from '../models/login-user.model';
import { RegisterUser } from '../models/register-user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  postRegisterUser(user: RegisterUser): Observable<RegisterUser> {
    return this.http.post<RegisterUser>(
      `${environment.apiURL}/authentication/register`,
      user
    );
  }
  postLoginUser(user: LoginUser): Observable<LoginUser> {
    return this.http
      .post<LoginUser>(`${environment.apiURL}/authentication/login`, user)
      .pipe(tap((response) => this.setSession(response)));
  }

  private setSession(authResult) {
    const token = authResult.token;
    localStorage.setItem('token', token);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('expires_at');
    this.router.navigate(['authentication', 'login']);
    this.notificationService.showMessage('Logout efetuado com sucesso!');
  }

  get token(): string {
    return localStorage.getItem('token');
  }
}
