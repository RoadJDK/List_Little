import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor
} from '@angular/common/http';
import { mergeMap, Observable, switchMap } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private readonly auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<any> {
    return this.auth.getAccessTokenSilently()
        .pipe(
            mergeMap((token) => {
                return next.handle(req.clone({
                  headers: req.headers.set('Authorization', `Bearer ${token}`)
                }));
            })
        );
  }
}
