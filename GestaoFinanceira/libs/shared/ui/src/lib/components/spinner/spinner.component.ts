import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgressSpinnerModule } from 'primeng/progressspinner';

@Component({
  selector: 'lib-spinner',
  imports: [CommonModule, ProgressSpinnerModule],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.css',
})
export class SpinnerComponent {}
