import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeEmailComponent } from './change-email/change-email.component';
import { ChangePasswordComponent } from './change-password/change-password.component';

@Component({
  selector: 'lib-security',
  imports: [CommonModule, ChangeEmailComponent, ChangePasswordComponent],
  templateUrl: './security.component.html',
  styleUrl: './security.component.css',
})
export class SecurityComponent {}
