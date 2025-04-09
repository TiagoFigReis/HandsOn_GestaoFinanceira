import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'lib-confirm-dialog',
  imports: [CommonModule, ConfirmDialog, ButtonComponent],
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.css',
})
export class ConfirmDialogComponent {}
