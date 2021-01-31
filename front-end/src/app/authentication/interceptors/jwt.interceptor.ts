import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token');
    const result = !!token ? this.addAuthorizationHeader(req, token) : req;
    return next.handle(result);
  }

  addAuthorizationHeader(request: HttpRequest<any>, token: string) {
    const cloned = request.clone({
      headers: request.headers.set('Authorization', 'Bearer '.concat(token))
    });

    return cloned;
  }
}
