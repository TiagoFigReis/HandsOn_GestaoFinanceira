import { Route } from '@angular/router';

export const usersRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./users/users.component').then((m) => m.UsersComponent),
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/users-list').then((m) => m.usersListRoutes),
      },
      {
        path: 'create',
        loadChildren: () => import('@farm/user').then((m) => m.userRoutes),
      },
      {
        path: ':id',
        loadChildren: () => import('@farm/user').then((m) => m.userRoutes),
      },
    ],
  },
];
