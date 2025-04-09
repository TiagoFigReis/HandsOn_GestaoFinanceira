import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'lib-form-group',
  imports: [CommonModule],
  templateUrl: './form-group.component.html',
  styleUrl: './form-group.component.css',
})
export class FormGroupComponent {
  @Input() style: 'row' | 'col' = 'row';
  @Input() responsive = false;
}
