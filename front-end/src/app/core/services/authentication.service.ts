import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUser, RegisterUser } from '@auth/models';
import { NotificationService } from '@core/services';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Token } from '../../authentication/models/token.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private router: Router,
    private notificationService: NotificationService
  ) {}

  postRegisterUser(user: RegisterUser): Observable<Token> {
    return this.http
      .post<Token>(`${environment.apiURL}/authentication/register`, user)
      .pipe(tap((token) => this.setSession(token)));
  }
  postLoginUser(user: LoginUser): Observable<Token> {
    return this.http
      .post<Token>(`${environment.apiURL}/authentication/login`, user)
      .pipe(tap((response) => this.setSession(response)));
  }

  private setSession(authResult: Token) {
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
