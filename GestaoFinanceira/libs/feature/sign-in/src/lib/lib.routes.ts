import { Route } from '@angular/router';

export const signInRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./sign-in/sign-in.component').then((m) => m.SignInComponent),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./sign-in/form/form.component').then((m) => m.FormComponent),
      },
      {
        path: 'forgot-password',
        loadComponent: () =>
          import('./sign-in/forgot-password/forgot-password.component').then(
            (m) => m.ForgotPasswordComponent
          ),
      },
    ],
  },
];
