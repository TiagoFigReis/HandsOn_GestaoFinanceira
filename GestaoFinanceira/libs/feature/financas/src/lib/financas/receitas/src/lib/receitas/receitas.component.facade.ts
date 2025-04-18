import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  ReceitaFacade,
  ConfirmationService,
  Receita,
} from '@farm/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class ReceitasComponentFacade {
    private receitaSubject = new BehaviorSubject<Receita | null>(null);
    private loadingSubject = new BehaviorSubject<boolean>(false);
  
    id: string | undefined;
    receita$: Observable<Receita | null> = this.receitaSubject.asObservable();
    loading$: Observable<boolean> = this.loadingSubject.asObservable();
  
    constructor(
      private receitaFacade: ReceitaFacade,
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
    
        this.receitaFacade
        .getById(id)
          .pipe(
            tap(
              (receita) => {
                this.receitaSubject.next(receita);
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
        this.receitaSubject.next(null);
    }

    submit(receita: Receita) {
        this.confirmationService.confirm({
          message: `Deseja ${this.id ? 'atualizar' : 'criar'} a receita?`,
          accept: () => (this.id ? this.update(receita) : this.add(receita)),
        });
      }

    add(receita: Receita) {
        this.receitaFacade.create(receita).subscribe(() => {
          this.router.navigate(['/app/financas/receitas']);
        });
      }
    
    update(receita: Receita) {
        this.receitaFacade.update(receita).subscribe(() => {
          this.router.navigate(['/app/financas/receitas']);
        });
      }
}