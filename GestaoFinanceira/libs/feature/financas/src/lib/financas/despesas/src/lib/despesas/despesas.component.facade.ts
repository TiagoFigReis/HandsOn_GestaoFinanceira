import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  DespesaFacade,
  ConfirmationService,
  Despesa,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class DespesasComponentFacade {
    private despesaSubject = new BehaviorSubject<Despesa | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(false);
  
    id: string | undefined;
    despesa$: Observable<Despesa | null> = this.despesaSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private despesaFacade: DespesaFacade,
      private confirmationService: ConfirmationService,
      private router: Router,
    ) {}

    load(id: string | undefined) {
        if(!id){
          this.id = id;
          return
        }

        this.id = id;
    
        this.loadingSubject.next(true);
    
        this.despesaFacade
        .getById(id)
          .pipe(
            tap(
              (despesa) => {
                this.despesaSubject.next(despesa);
                this.loadingSubject.next(false);
              },
              (error) => {
                const code = error.code;
                if (code === 400 || code === 404) this.router.navigate(['/404']);
              },
            ),
          )
          .subscribe();
    }

    reset() {
        this.despesaSubject.next(null);
    }

    submit(despesa: Despesa) {
        this.confirmationService.confirm({
          message: `Deseja ${this.id ? 'atualizar' : 'criar'} a despesa?`,
          accept: () => (this.id ? this.update(despesa) : this.add(despesa)),
        });
      }

    add(despesa: Despesa) {
        this.despesaFacade.create(despesa).subscribe(() => {
          this.router.navigate(['/app/financas/despesas']);
        });
      }
    
    update(despesa: Despesa) {
        this.despesaFacade.update(despesa).subscribe(() => {
          this.router.navigate(['/app/financas/despesas']);
        });
      }
}