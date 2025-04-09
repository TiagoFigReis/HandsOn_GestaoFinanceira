import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from '@farm/header';
import { SidebarComponent } from '@farm/sidebar';
import { MainComponent } from '@farm/main';
import { FooterComponent } from '@farm/footer';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { MenuItem } from 'primeng/api';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { UserFacade } from '@farm/core';
import { SpinnerComponent } from '@farm/ui';

@Component({
  selector: 'lib-master-page',
  imports: [
    CommonModule,
    RouterModule,
    HeaderComponent,
    SidebarComponent,
    MainComponent,
    FooterComponent,
    TieredMenuModule,
    ProgressSpinnerModule,
    SpinnerComponent,
  ],
  templateUrl: './master-page.component.html',
  styleUrl: './master-page.component.css',
})
export class MasterPageComponent implements OnInit, OnDestroy {
  menuItems: MenuItem[] = [];
  menuVisible = false;
  loading = true;

  constructor(private userFacade: UserFacade) {}

  ngOnInit(): void {
    this.userFacade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.userFacade.me().subscribe((user) => {
      this.loadMenu(user.role as string);
    });
  }

  ngOnDestroy(): void {
    this.userFacade.reset();
  }

  loadMenu(userRole: string) {
    const menuItems: MenuItem[] = [];

    menuItems.push({
      label: 'Gerenciar Finanças',
      icon: 'pi pi-fw pi-users',
      items: [
        {
          label: 'Receitas',
          icon: 'pi pi-fw pi-user-plus',
          routerLink: '/app/financas/receitas',
        },
        {
          label: 'Despesas',
          icon: 'pi pi-fw pi-users',
          routerLink: '/app/financas/despesas',
        },
      ],
    });

    if (userRole === 'Admin') {
      menuItems.push({
        label: 'Usuários',
        icon: 'pi pi-fw pi-users',
        items: [
          {
            label: 'Cadastrar',
            icon: 'pi pi-fw pi-user-plus',
            routerLink: '/app/users/create',
          },
          {
            label: 'Gerenciar',
            icon: 'pi pi-fw pi-users',
            routerLink: '/app/users',
          },
        ],
      });
    }

    this.menuItems = menuItems;
  }
}
