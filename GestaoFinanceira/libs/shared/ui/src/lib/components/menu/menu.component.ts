import { Component, Input, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { Menu } from 'primeng/menu';

@Component({
  selector: 'lib-menu',
  imports: [CommonModule, Menu],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
})
export class MenuComponent {
  @Input() id = '';
  @Input() items: MenuItem[] = [];
  @Input() popup = false;

  @ViewChild(Menu) menu: Menu | undefined;

  toggle(event: any) {
    this.menu?.toggle(event);
  }
}
