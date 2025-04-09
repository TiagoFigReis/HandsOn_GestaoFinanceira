import { Route } from '@angular/router';

export const settingsRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./settings/settings.component').then((m) => m.SettingsComponent),
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'account',
      },
      {
        path: 'account',
        loadChildren: () =>
          import('@farm/account').then((m) => m.accountRoutes),
      },
      {
        path: 'security',
        loadChildren: () =>
          import('@farm/security').then((m) => m.securityRoutes),
      },
    ],
  },
];
