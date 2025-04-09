import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../models/user.model';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { UserService } from '../services/user/user.service';
import { NotificationService } from '../services/notification/notification.service';

@Injectable({
  providedIn: 'root',
})
export class UserFacade {
  private userSubject = new BehaviorSubject<User | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(true);

  user$: Observable<User | null> = this.userSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable();

  constructor(
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private notificationService: NotificationService,
  ) {}

  me(): Observable<User> {
    return this.userService.me().pipe(
      tap((response) => {
        this.userSubject.next(response);
        this.loadingSubject.next(false);
      }),
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar as informações do usuário!',
          );
        },
      }),
    );
  }

  reset(): void {
    this.userSubject.next(null);
    this.loadingSubject.next(true);
  }

  getAllUsers(): Observable<User[]> {
    return this.userService.getAllUsers().pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar os usuários!',
          );
        },
      }),
    );
  }

  getUserById(id: string): Observable<User> {
    return this.userService.getUserById(id).pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível carregar o usuário!',
          );
        },
      }),
    );
  }

  checkEmail(email: string): Observable<{ emailExists: boolean }> {
    return this.userService.checkEmail(email).pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Ocorreu um erro ao verificar o e-mail!',
          );
        },
      }),
    );
  }

  checkPhone(phone: string): Observable<{ phoneExists: boolean }> {
    return this.userService.checkPhone(phone).pipe(
      tap({
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Ocorreu um erro ao verificar o telefone!',
          );
        },
      }),
    );
  }

  registerMe(user: User): Observable<{ token: string }> {
    return this.userService.registerMe(user).pipe(
      tap({
        next: (response) => {
          this.notificationService.success(
            'Sucesso!',
            'Sua conta foi criada com sucesso!',
          );

          this.authenticationService.createSession(response.token);

          this.me().subscribe();
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível criar a sua conta!',
          );
        },
      }),
    );
  }

  createUser(user: User): Observable<User> {
    return this.userService.createUser(user).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Usuário cadastrado com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível criar o usuário!',
          );
        },
      }),
    );
  }

  updateUser(user: User): Observable<User> {
    return this.userService.updateUser(user).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Usuário atualizado com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível atualizar o usuário!',
          );
        },
      }),
    );
  }

  updateMe(user: User): Observable<User> {
    return this.userService.updateMe(user).pipe(
      tap({
        next: () => {
          this.userSubject.next(user);
          this.notificationService.success(
            'Sucesso!',
            'Informações atualizadas com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível atualizar o usuário!',
          );
        },
      }),
    );
  }

  deleteUser(id: string): Observable<void> {
    return this.userService.deleteUser(id).pipe(
      tap({
        next: () => {
          this.notificationService.success(
            'Sucesso!',
            'Usuário excluído com sucesso!',
          );
        },
        error: () => {
          this.notificationService.error(
            'Erro!',
            'Não foi possível excluir o usuário!',
          );
        },
      }),
    );
  }
}
