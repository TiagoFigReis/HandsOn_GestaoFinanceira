import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-list-receitas',
  imports: [CommonModule, ButtonComponent],
  templateUrl: './list-receitas.component.html',
  styleUrl: './list-receitas.component.css',
})
export class ListReceitasComponent {}
