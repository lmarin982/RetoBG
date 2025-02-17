import { Routes } from '@angular/router';
import { MainLayoutComponent } from './Pages/mainLayout/mainLayout.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  // Ruta para el login, que se carga fuera del layout
  {
    path: 'login',
    loadComponent: () =>
      import('./Pages/login/login.component').then((m) => m.LoginComponent),
  },
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'home',
        loadComponent: () =>
          import('./Pages/home/home.component').then((m) => m.HomeComponent),
      },
      {
        path: 'clientes',
        loadComponent: () =>
          import('./Pages/clientes/clientes.component').then(
            (m) => m.ClientesComponent
          ),
      },
      {
        path: 'facturas',
        loadComponent: () =>
          import('./Pages/facturas/facturas.component').then(
            (m) => m.FacturasComponent
          ),
      },
      {
        path: 'usuarios',
        loadComponent: () =>
          import('./Pages/usuario/usuario.component').then(
            (m) => m.UsuarioComponent
          ),
      },
    ],
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];
