import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../models/user.model';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { ReceitaService } from '../services/receita/receita.service';
import { NotificationService } from '../services/notification/notification.service';
import { Receita } from '../models/receita.model';

@Injectable({
  providedIn: 'root',
})
export class ReceitaFacade {
    private userSubject = new BehaviorSubject<User | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    user$: Observable<User | null> = this.userSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private authenticationService: AuthenticationService,
      private receitaService: ReceitaService,
      private notificationService: NotificationService,
    ) {}

    getAll(): Observable<Receita[]> {
      return this.receitaService.getAll().pipe(
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

    getById(id: string): Observable<Receita> {
      return this.receitaService.getById(id).pipe(
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

    create(receita: Receita): Observable<Receita> {
      return this.receitaService.create(receita).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Receita cadastrada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível cadastrar a receita!',
            );
          },
        }),
      );
    }
  
    update(receita: Receita): Observable<Receita> {
      return this.receitaService.update(receita).pipe(
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

    delete(id: string): Observable<void> {
      return this.receitaService.delete(id).pipe(
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