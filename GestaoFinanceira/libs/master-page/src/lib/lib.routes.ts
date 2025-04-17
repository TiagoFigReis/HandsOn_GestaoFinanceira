import { Route } from '@angular/router';
import { AuthenticatedGuard, IsAdminGuard } from '@farm/core';

export const masterPageRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./master-page/master-page.component').then(
        (m) => m.MasterPageComponent,
      ),
    canActivate: [AuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/dashboard').then((m) => m.dashboardRoutes),
      },
      {
        path: 'users',
        loadChildren: () => import('@farm/users').then((m) => m.usersRoutes),
        canActivate: [IsAdminGuard],
      },
      {
        path: 'financas',
        loadChildren: () => import('@farm/financas').then((m) => m.FinancasRoutes),
      },
      {
        path: 'settings',
        loadChildren: () =>
          import('@farm/settings').then((m) => m.settingsRoutes),
      },
      {
        path: '**',
        redirectTo: 'not-found',
      },
    ],
  },
];
