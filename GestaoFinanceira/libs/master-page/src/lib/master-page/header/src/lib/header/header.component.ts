import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuItem } from 'primeng/api';
import { RouterModule } from '@angular/router';
import { AvatarComponent, ButtonComponent, MenuComponent } from '@farm/ui';
import { User, AuthFacade, UserFacade, UserRoles } from '@farm/core';
import { MenubarModule } from 'primeng/menubar';

@Component({
  selector: 'lib-header',
  imports: [
    CommonModule,
    RouterModule,
    AvatarComponent,
    MenuComponent,
    MenubarModule,
    ButtonComponent,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements OnInit {
  @Input() menuItems: MenuItem[] = [];
  @Input() menuVisible = false;
  @Output() menuVisibleChange = new EventEmitter<boolean>();

  user: User | null = null;
  avatarItems: MenuItem[] = [
    {
      label: 'Perfil',
      items: [
        {
          label: 'Configurações',
          icon: 'pi pi-fw pi-cog',
          routerLink: '/app/settings',
          styleClass: 'description',
        },
        {
          label: 'Sair',
          icon: 'pi pi-fw pi-sign-out',
          styleClass: 'description',
          iconClass: 'error',
          command: () => this.logout(),
        },
      ],
    },
  ];

  constructor(private authFacade: AuthFacade, private userFacade: UserFacade) {}

  get userRole(): string {
    if (!this.user) return '';

    return UserRoles[this.user.role as keyof typeof UserRoles];
  }

  ngOnInit(): void {
    this.userFacade.user$.subscribe((user) => {
      this.user = user;
    });
  }

  menuToggle(): void {
    this.menuVisible = !this.menuVisible;
    this.menuVisibleChange.emit(this.menuVisible);
  }

  logout(): void {
    this.authFacade.logout();
  }
}
