import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { ButtonComponent } from '@farm/ui';
import { DrawerModule } from 'primeng/drawer';
import { Menu } from 'primeng/menu';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'lib-sidebar',
  imports: [CommonModule, DrawerModule, Menu, ButtonComponent, RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent {
  @Input() menuItems: MenuItem[] = [];
  @Input() menuVisible = false;
  @Output() menuVisibleChange = new EventEmitter<boolean>();

  menuToggle(event: any): void {
    this.menuVisible = event;
    this.menuVisibleChange.emit(this.menuVisible);
  }
}
