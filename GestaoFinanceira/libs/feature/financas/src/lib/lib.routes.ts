import { Route } from '@angular/router';

export const FinancasRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./financas/financas.component').then((m) => m.FinancasComponent),
    children: [
      {
        path: 'receitas',
        loadChildren: () =>
          import('@farm/list-receitas').then((m) => m.ListReceitasRoutes),
      },
      {
        path: 'receitas/create',
        loadChildren: () => import('@farm/receitas').then((m) => m.ReceitasRoutes),
      },
      {
        path: 'receitas/:id',
        loadChildren: () => import('@farm/receitas').then((m) => m.ReceitasRoutes),
      },
      {
        path: 'despesas',
        loadChildren: () =>
          import('@farm/list-despesas').then((m) => m.ListDespesasRoutes),
      },
      {
        path: 'despesas/create',
        loadChildren: () => import('@farm/despesas').then((m) => m.DespesasRoutes),
      },
      {
        path: 'despesas/:id',
        loadChildren: () => import('@farm/despesas').then((m) => m.DespesasRoutes),
      },
      {
        path: 'relatorios',
        loadChildren: () => import('@farm/relatorios').then((m) => m.RelatoriosRoutes),
      },
    ],
  },
];
