import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Receita,
  ReceitaFacade,
  ConfirmationService,
} from '@farm/core';
import { Row, Action } from '@farm/ui';

@Injectable({
  providedIn: 'root',
})
export class ReceitaListComponentFacade {
  private receitasSubject = new BehaviorSubject<Row[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  receitas$: Observable<Row[]> = this.receitasSubject.asObservable();

  constructor(
    private receitaFacade: ReceitaFacade,
    private confirmationService: ConfirmationService,
  ) {}

  load() {
    this.loadingSubject.next(true);

    this.receitaFacade
        .getAll()
        .pipe(
        tap(
          (receitas) => {
            this.receitasSubject.next(
                receitas.map((receitas) => this.mapReceitaToRow(receitas)),
            );
            this.loadingSubject.next(false);
          },
          () => {
            this.loadingSubject.next(false);
          },
        ),
      )
      .subscribe();
  }

  private mapReceitaToRow(receita: Receita): Row {
    return {
      ...receita,
      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/financas/receitas/${receita.id}`,
        },
        {
              tooltip: 'Excluir',
              icon: 'pi pi-fw pi-trash',
              iconClass: 'error',
              command: (event, data) => {
                this.confirmationService.confirm({
                  header: 'Excluir Receita',
                  message: `Deseja excluir a receita ${data.firstName}?`,
                  accept: () => {
                    this.receitaFacade.delete(data.id).subscribe(() => {
                      this.load();
                    });
                  },
                });
              },
            }
      ] as Action[],
    };
  }
}
