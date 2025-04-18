import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, TableComponent, Row } from '@farm/ui';
import { ReceitaListComponentFacade } from './list-receitas.componet.facade';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-list-receitas',
  imports: [CommonModule, TableComponent, ButtonComponent],
  templateUrl: './list-receitas.component.html',
  styleUrl: './list-receitas.component.css',
})
export class ListReceitasComponent implements OnInit{
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: ReceitaListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.receitas$.subscribe((receitas) => {
      this.data = receitas;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}

const columns: Column[] = [
  {
    field: 'fonte',
    header: 'Fonte',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'valor',
    header: 'Valor',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'descricao',
    header: 'Descrição',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'data',
    header: 'Data',
    type: 'date',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,

  },
  {
    field: 'createdAt',
    header: 'Criado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'updatedAt',
    header: 'Atualizado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
]
