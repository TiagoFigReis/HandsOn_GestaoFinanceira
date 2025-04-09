import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { HttpContextToken } from '@angular/common/http';

export const BYPASS_INTERCEPTORS = new HttpContextToken<boolean>(() => false);

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ): Observable<HttpEvent<unknown>> {
    const bypassInterceptor = request.context.get(BYPASS_INTERCEPTORS);

    if (bypassInterceptor) return next.handle(request);

    const token = this.authenticationService.token;
    const tokenExpired = this.authenticationService.tokenExpired;

    if (tokenExpired) this.authenticationService.logout();

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }

    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(error);
      }),
    );
  }
}
