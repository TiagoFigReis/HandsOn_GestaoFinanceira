import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { HttpContext } from '@angular/common/http';
import { BYPASS_INTERCEPTORS } from '../../interceptors/authentication/authentication.interceptor';
import { RequestService } from '../request/request.service';
import { Token } from '../../models/token.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService extends RequestService {
  httpOptionsBypassInterceptor = {
    ...this.httpOptions,
    context: new HttpContext().set(BYPASS_INTERCEPTORS, true),
  };

  login(email: string, password: string) {
    const body = {
      email,
      password,
    };

    return this.httpClient
      .post<{
        token: string;
      }>(
        `${this.authApiUrl}/authenticate`,
        JSON.stringify(body),
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  loginWithGoogle(code: string) {
    const body = {
      code,
    };

    return this.httpClient
      .post<{
        token: string;
      }>(
        `${this.authApiUrl}/authenticate-with-google`,
        JSON.stringify(body),
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  logout(): void {
    this.destroySession();
    this.router.navigate(['/sign-in']);
  }

  createSession(token: string): void {
    localStorage.setItem('token', token);
    this.router.navigate(['/app']);
  }

  destroySession(): void {
    localStorage.removeItem('token');
  }

  sendPasswordResetEmail(email: string) {
    const body = {
      email,
    };

    return this.httpClient
      .post<void>(
        `${this.authApiUrl}/send-password-reset-token`,
        JSON.stringify(body),
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  sendEmailChangeToken(email: string, confirmEmail: string) {
    const body = {
      email,
      confirmEmail,
    };

    return this.httpClient
      .post<void>(
        `${this.authApiUrl}/send-email-change-token`,
        JSON.stringify(body),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  checkPasswordResetToken(key: string, token: string) {
    return this.httpClient
      .get<boolean>(
        `${this.authApiUrl}/check-password-reset-token?token=${token}&key=${key}`,
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  changePassword(
    key: string,
    token: string,
    password: string,
    confirmPassword: string,
  ) {
    const body = {
      key,
      token,
      password,
      confirmPassword,
    };

    return this.httpClient
      .patch<void>(
        `${this.authApiUrl}/change-password`,
        JSON.stringify(body),
        this.httpOptionsBypassInterceptor,
      )
      .pipe(catchError(this.handleError));
  }

  changeEmail(token: string, email: string) {
    const body = {
      token,
      email,
    };

    return this.httpClient
      .patch<void>(
        `${this.authApiUrl}/change-email`,
        JSON.stringify(body),
        this.httpOptions,
      )
      .pipe(catchError(this.handleError));
  }

  get token(): string | null {
    const token = localStorage.getItem('token');
    return token;
  }

  get decodedToken(): Token {
    const token = this.token || '';
    const tokenExpired = this.jwtHelper.isTokenExpired(token);

    if (!token || tokenExpired) {
      this.logout();
    }

    const decodedToken = this.jwtHelper.decodeToken(token) as Token;

    return decodedToken;
  }

  get isAuthenticated(): boolean {
    return this.token !== null && !this.tokenExpired;
  }

  get tokenExpired(): boolean {
    return this.jwtHelper.isTokenExpired(this.token);
  }
}
