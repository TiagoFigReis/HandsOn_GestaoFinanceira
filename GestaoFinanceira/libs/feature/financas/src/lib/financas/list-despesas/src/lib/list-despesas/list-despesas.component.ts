import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-list-despesas',
  imports: [CommonModule, ButtonComponent],
  templateUrl: './list-despesas.component.html',
  styleUrl: './list-despesas.component.css',
})
export class ListDespesasComponent {}
