import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: '',
    loadComponent: () => import('@farm/home').then((m) => m.HomeComponent),
  },
  {
    path: 'sign-in',
    loadChildren: () => import('@farm/sign-in').then((m) => m.signInRoutes),
  },
  {
    path: 'sign-up',
    loadChildren: () => import('@farm/sign-up').then((m) => m.signUpRoutes),
  },
  {
    path: 'change-password',
    loadChildren: () =>
      import('@farm/change-password').then((m) => m.changePasswordRoutes),
  },
  {
    path: 'app',
    loadChildren: () =>
      import('@farm/master-page').then((m) => m.masterPageRoutes),
  },
  {
    path: '**',
    loadComponent: () =>
      import('@farm/not-found').then((m) => m.NotFoundComponent),
  },
];
