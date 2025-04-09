import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  notificationLife = 3000;

  constructor(private messageService: MessageService) {}

  success(title: string, message: string): void {
    this.messageService.add({
      severity: 'success',
      summary: title,
      detail: message,
      life: this.notificationLife,
    });
  }

  info(title: string, message: string): void {
    this.messageService.add({
      severity: 'info',
      summary: title,
      detail: message,
      life: this.notificationLife,
    });
  }

  warn(title: string, message: string): void {
    this.messageService.add({
      severity: 'warn',
      summary: title,
      detail: message,
      life: this.notificationLife,
    });
  }

  error(title: string, message: string): void {
    this.messageService.add({
      severity: 'error',
      summary: title,
      detail: message,
      life: this.notificationLife,
    });
  }

  clear(): void {
    this.messageService.clear();
  }
}
