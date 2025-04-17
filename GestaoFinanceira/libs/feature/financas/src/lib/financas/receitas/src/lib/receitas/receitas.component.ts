import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Receita } from '@farm/core';
import { CardComponent, ReceitaFormComponent } from '@farm/ui';
import { ReceitasComponentFacade } from './receitas.component.facade';

@Component({
  selector: 'lib-receita',
  imports: [CommonModule, CardComponent, ReceitaFormComponent, RouterModule],
  templateUrl: './receitas.component.html',
  styleUrl: './receitas.component.css',
})
export class ReceitaComponent implements OnInit, OnDestroy {
  id: string | undefined;
  receita: Receita | undefined;
  loading = false;

  title = 'Adicionar Receita';
  description = 'Preencha os campos abaixo para adicionar uma receita';
  submitLabel = 'Adicionar';

  constructor(
    private route: ActivatedRoute,
    private facade: ReceitasComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      return;
    }

    this.title = 'Editar Usuário';
    this.description = 'Preencha os campos abaixo para editar o usuário';
    this.submitLabel = 'Editar';

    this.facade.load(this.id);

    this.facade.receita$.subscribe((receita) => {
      if (!receita) return;

      this.receita = receita;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(receita: Receita) {
    this.facade.submit(receita);
  }
}