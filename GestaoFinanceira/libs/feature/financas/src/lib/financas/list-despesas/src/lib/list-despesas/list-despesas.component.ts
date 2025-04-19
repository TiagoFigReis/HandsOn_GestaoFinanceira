import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, TableComponent, Row } from '@farm/ui';
import { DespesaListComponentFacade } from './list-despesas.component.facade';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-list-despesas',
  imports: [CommonModule, TableComponent, ButtonComponent],
  templateUrl: './list-despesas.component.html',
  styleUrl: './list-despesas.component.css',
})
export class ListDespesasComponent implements OnInit{
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: DespesaListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.despesas$.subscribe((despesas) => {
      this.data = despesas;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}

const columns: Column[] = [
  {
    field: 'categoria',
    header: 'Categoria',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'valor',
    header: 'Valor',
    type: 'currency',
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
