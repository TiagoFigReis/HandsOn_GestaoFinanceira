import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  Despesa,
  DespesaFacade,
  ConfirmationService,
} from '@farm/core';
import { Row, Action } from '@farm/ui';

@Injectable({
  providedIn: 'root',
})
export class DespesaListComponentFacade {
  private despesasSubject = new BehaviorSubject<Row[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$: Observable<boolean> = this.loadingSubject.asObservable();
  despesas$: Observable<Row[]> = this.despesasSubject.asObservable();

  constructor(
    private despesaFacade: DespesaFacade,
    private confirmationService: ConfirmationService,
  ) {}

  load() {
    this.loadingSubject.next(true);
  
    this.despesaFacade
      .getAll()
      .pipe(
        tap(async (despesas) => {
          const rows: Row[] = [];
  
          for (const despesa of despesas) {
            let exists = false
            if(despesa.comprovante){
              exists = true
            }
            rows.push(this.mapReceitaToRow(despesa, exists));
          }
  
          this.despesasSubject.next(rows);
          this.loadingSubject.next(false);
        }, () => {
          this.loadingSubject.next(false);
        })
      )
      .subscribe();
  }

  private mapReceitaToRow(despesa: Despesa, exists: boolean): Row {
    return {
      ...despesa,
      exists,
      actions: [
        {
          tooltip: 'Editar',
          icon: 'pi pi-fw pi-pencil',
          iconClass: 'primary',
          routerLink: `/app/financas/despesas/${despesa.id}`,
        },
        {
              tooltip: 'Excluir',
              icon: 'pi pi-fw pi-trash',
              iconClass: 'error',
              command: (event, data) => {
                this.confirmationService.confirm({
                  header: 'Excluir Despesa',
                  message: `Deseja excluir a despesa ${data.firstName}?`,
                  accept: () => {
                    this.despesaFacade.delete(data.id).subscribe(() => {
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
