import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import { ProductosComponent } from './productos/product-list/productos.component';
import { authGuard } from './auth/guard/auth.guard';
import { redireccionGuard } from './auth/guard/redireccion.guard';
import { isNotAuthenticatedGuard } from './auth/guard/is-not-authenticated.guard';

const routes: Routes = [
  {
    path: 'productos',
    canActivate: [authGuard],
    data: { roles: ['administrador'] },
    loadChildren: () =>
      import('./productos/productos.module').then((m) => m.ProductosModule), //Carga diferida (Lazy Loading)
  },
  {
    path: 'cliente',
    canActivate: [authGuard],
    data: { roles: ['cliente'] },
    component: ClienteComponent,
  },

  {
    path: 'informacion',
    loadComponent: () => import('./standalone/informacion/informacion.component')
    .then(m => m.InformacionComponent)

  },
  {
    path: 'auth',
    canActivate: [isNotAuthenticatedGuard],
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  {
    // dominion.com/'' --> monta el componente Productos
    path: '',
    canActivate: [redireccionGuard],
    component: ProductosComponent,
  },
  {
    path: '**',
    redirectTo: 'auth/login',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
