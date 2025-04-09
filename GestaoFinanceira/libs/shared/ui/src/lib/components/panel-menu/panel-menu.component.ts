import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { PanelMenu } from 'primeng/panelmenu';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'lib-panel-menu',
  imports: [CommonModule, RouterModule, PanelMenu],
  templateUrl: './panel-menu.component.html',
  styleUrl: './panel-menu.component.css',
})
export class PanelMenuComponent {
  @Input() items: MenuItem[] = [];
}
