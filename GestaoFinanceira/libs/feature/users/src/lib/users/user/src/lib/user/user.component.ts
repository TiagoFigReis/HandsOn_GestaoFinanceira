import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { User } from '@farm/core';
import { CardComponent, UserFormComponent } from '@farm/ui';
import { UserComponentFacade } from './user.component.facade';

@Component({
  selector: 'lib-user',
  imports: [CommonModule, CardComponent, UserFormComponent, RouterModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent implements OnInit, OnDestroy {
  id: string | undefined;
  user: User | undefined;
  loading = false;
  selectRole = false;

  title = 'Criar Usuário';
  description = 'Preencha os campos abaixo para criar um novo usuário';
  submitLabel = 'Cadastrar';

  constructor(
    private route: ActivatedRoute,
    private facade: UserComponentFacade,
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') || undefined;

    if (!this.id) {
      this.selectRole = true;
      return;
    }

    this.title = 'Editar Usuário';
    this.description = 'Preencha os campos abaixo para editar o usuário';
    this.submitLabel = 'Editar';

    this.facade.load(this.id);

    this.facade.user$.subscribe((user) => {
      if (!user) return;

      this.user = user;
    });

    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.selectRole.subscribe((selectRole) => {
      this.selectRole = selectRole;
    });
  }

  ngOnDestroy() {
    this.facade.reset();
  }

  onSubmit(user: User) {
    delete user.password;

    this.facade.submit(user);
  }
}
