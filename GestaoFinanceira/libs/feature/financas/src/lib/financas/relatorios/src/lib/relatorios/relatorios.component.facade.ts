import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, forkJoin, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import {
  ReceitaFacade,
  Receita,
  DespesaFacade,
  Despesa
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class RelatorioComponentFacade {
  private receitaSubject = new BehaviorSubject<Receita[] | null>(null);
  private despesaSubject = new BehaviorSubject<Despesa[] | null>(null);
  private loadingSubject = new BehaviorSubject<boolean>(false); // Único loading

  id: string | undefined;
  receita$: Observable<Receita[] | null> = this.receitaSubject.asObservable();
  despesa$: Observable<Despesa[] | null> = this.despesaSubject.asObservable();
  loading$: Observable<boolean> = this.loadingSubject.asObservable(); // Observable de loading único

  constructor(
    private receitaFacade: ReceitaFacade,
    private despesaFacade: DespesaFacade,
    private router: Router
  ) {}

  load() {
    this.loadingSubject.next(true); 

    forkJoin({
      receitas: this.receitaFacade.getAll(),
      despesas: this.despesaFacade.getAll()
    }).pipe(
      tap(
        ({ receitas, despesas }) => {
          this.receitaSubject.next(receitas);
          this.despesaSubject.next(despesas);
        },
        (error) => {
          const code = error.code;
          if (code === 400 || code === 404) {
            this.router.navigate(['/404']);
          }
        }
      ),
      catchError(() => {
        this.loadingSubject.next(false);
        return of(null); 
      })
    ).subscribe(() => {
      this.loadingSubject.next(false); 
    });
  }

  reset() {
    this.receitaSubject.next(null);
    this.despesaSubject.next(null);
  }
}
