import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { DespesaService } from '../services/despesa/despesa.service';
import { NotificationService } from '../services/notification/notification.service';
import { Despesa } from '../models/despesa.model';

@Injectable({
  providedIn: 'root',
})
export class DespesaFacade {
    private despesaSubject = new BehaviorSubject<Despesa | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(true);
  
    despesa$: Observable<Despesa | null> = this.despesaSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private despesaService: DespesaService,
      private notificationService: NotificationService,
    ) {}

    getAll(): Observable<Despesa[]> {
      return this.despesaService.getAll().pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar as despesas!',
            );
          },
        }),
      );
    }

    getById(id: string): Observable<Despesa> {
      return this.despesaService.getById(id).pipe(
        tap({
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível carregar a despesa!',
            );
          },
        }),
      );
    }

    create(despesa: Despesa): Observable<Despesa> {
      return this.despesaService.create(despesa).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Despesa cadastrada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível cadastrar a despesa!',
            );
          },
        }),
      );
    }
  
    update(despesa: Despesa): Observable<Despesa> {
      return this.despesaService.update(despesa).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Despesa atualizada com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível atualizar a despesa!',
            );
          },
        }),
      );
    }

    delete(id: string): Observable<void> {
      return this.despesaService.delete(id).pipe(
        tap({
          next: () => {
            this.notificationService.success(
              'Sucesso!',
              'Despesa excluída com sucesso!',
            );
          },
          error: () => {
            this.notificationService.error(
              'Erro!',
              'Não foi possível excluir a despesa!',
            );
          },
        }),
      );
    }
}