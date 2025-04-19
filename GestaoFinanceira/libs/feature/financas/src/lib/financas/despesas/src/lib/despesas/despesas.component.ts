import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Despesa } from '@farm/core';
import { CardComponent, DespesaFormComponent } from '@farm/ui';
import { DespesasComponentFacade } from './despesas.component.facade';

@Component({
  selector: 'lib-despesa',
  imports: [CommonModule, CardComponent, DespesaFormComponent, RouterModule],
  templateUrl: './despesas.component.html',
  styleUrl: './despesas.component.css',
})
export class DespesasComponent implements OnInit, OnDestroy {
  id: string | undefined;
  despesa: Despesa | undefined;
  loading = false;

  title = 'Adicionar Despesa';
  description = 'Preencha os campos abaixo para adicionar uma despesa';
  submitLabel = 'Adicionar';

  constructor(
    private route: ActivatedRoute,
    private facade: DespesasComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    this.facade.load(this.id);

    if (!this.id) {
      return;
    }

    this.title = 'Editar Despesa';
    this.description = 'Preencha os campos abaixo para editar a despesa';
    this.submitLabel = 'Editar';

    this.facade.despesa$.subscribe((despesa) => {
      if (!despesa) return;

      this.despesa = despesa;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(despesa: Despesa) {
    this.facade.submit(despesa);
  }
}