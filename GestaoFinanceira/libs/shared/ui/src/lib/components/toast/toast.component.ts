import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'lib-toast',
  imports: [CommonModule, ToastModule],
  templateUrl: './toast.component.html',
  styleUrl: './toast.component.css',
})
export class ToastComponent {}
