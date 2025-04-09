import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, TableComponent, Row } from '@farm/ui';
import { UsersListComponentFacade } from './users-list.component.facade';

@Component({
  selector: 'lib-users-list',
  imports: [CommonModule, TableComponent],
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.css',
})
export class UsersListComponent implements OnInit {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: UsersListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.users$.subscribe((users) => {
      this.data = users;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}

const columns: Column[] = [
  {
    field: 'firstName',
    header: 'Name',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'lastName',
    header: 'Sobrenome',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'email',
    header: 'Email',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'phoneNumber',
    header: 'Telefone',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'role',
    header: 'Função',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
    fraction: 0.5,
  },
  {
    field: 'createdAt',
    header: 'Criado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: false,
  },
  {
    field: 'updatedAt',
    header: 'Atualizado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: false,
  },
  {
    field: 'status',
    header: 'Status',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
    fraction: 0.5,
  },
];
