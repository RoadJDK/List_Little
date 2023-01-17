import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor, HttpErrorResponse
} from '@angular/common/http';
import {catchError, mergeMap, Observable, throwError} from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment.prod';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private readonly auth: AuthService, private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return this.auth.getAccessTokenSilently()
      .pipe(
          mergeMap((token) => {
              return next.handle(req.clone({
                headers: req.headers.set('Authorization', `Bearer ${token}`)
              }))
          }),
          catchError((error: HttpErrorResponse) => {
            if (error.status === 403) {
                this.auth.logout({returnTo: environment.auth.redirectUri})
              }
              return throwError(error);
          }));
  }
}