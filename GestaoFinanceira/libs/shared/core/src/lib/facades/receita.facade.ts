import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ReceitaService } from '../services/receita/receita.service';
import { NotificationService } from '../services/notification/notification.service';
import { Receita } from '../models/receita.model';

@Injectable({
  providedIn: 'root',
})
export class ReceitaFacade {
    private receitaSubject = new BehaviorSubject<Receita | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    receita$: Observable<Receita | null> = this.receitaSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private receitaService: ReceitaService,
      private notificationService: NotificationService,
    ) {}

    getAll(): Observable<Receita[]> {
      return this.receitaService.getAll().pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar as receitas!',
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
              'Não foi possível carregar a receita!',
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
              'Receita atualizada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível atualizar a receita!',
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
              'Receita excluída com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível excluir a receita!',
            );
          },
        }),
      );
    }
}