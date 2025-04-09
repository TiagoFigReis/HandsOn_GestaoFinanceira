import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { NotificationService } from '../services/notification/notification.service';
import { Token } from '../models/token.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthFacade {
  constructor(
    private authService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router,
  ) {}

  get isAuthenticated(): boolean {
    return this.authService.isAuthenticated;
  }

  get decodedToken(): Token {
    return this.authService.decodedToken;
  }

  login(
    email: string,
    password: string,
    rememberMe: false,
  ): Observable<{ token: string }> {
    return this.authService.login(email, password).pipe(
      tap({
        next: (response) => {
          this.authService.createSession(response.token);
          this.notificationService.success(
            'Sucesso!',
            'Login efetuado com sucesso!',
          );

          if (rememberMe) localStorage.setItem('email', email);
          else localStorage.removeItem('email');
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Usuário ou senha inválidos!',
          );
        },
      }),
    );
  }

  logout(): void {
    this.authService.logout();
    this.notificationService.success(
      'Sucesso!',
      'Logout efetuado com sucesso!',
    );
  }

  sendPasswordResetEmail(email: string): Observable<void> {
    return this.authService.sendPasswordResetEmail(email).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'E-mail de recuperação de senha enviado!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível enviar o e-mail de recuperação de senha!',
          );
        },
      }),
    );
  }

  sendEmailChangeToken(email: string, confirmEmail: string): Observable<void> {
    return this.authService.sendEmailChangeToken(email, confirmEmail).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'E-mail de alteração de e-mail enviado!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível enviar o e-mail de alteração de e-mail!',
          );
        },
      }),
    );
  }

  checkPasswordResetToken(key: string, token: string): Observable<boolean> {
    return this.authService.checkPasswordResetToken(key, token).pipe(
      tap({
        next: (result: boolean) => {
          if (!result) {
            this.notificationService.error(
              'Erro!',
              'Token de recuperação de senha inválido! Por favor, solicite um novo token.',
            );

            this.router.navigate(['/sign-in']);
          }
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Token de recuperação de senha inválido! Por favor, solicite um novo token.',
          );

          this.router.navigate(['/sign-in']);
        },
      }),
    );
  }

  changePassword(
    key: string,
    token: string,
    password: string,
    confirmPassword: string,
  ): Observable<void> {
    return this.authService
      .changePassword(key, token, password, confirmPassword)
      .pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Senha alterada com sucesso!',
            );

            this.router.navigate(['/sign-in']);
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível alterar a senha!',
            );
          },
        }),
      );
  }

  changeEmail(token: string, email: string): Observable<void> {
    return this.authService.changeEmail(token, email).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'E-mail alterado com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível alterar o e-mail!',
          );
        },
      }),
    );
  }
}
