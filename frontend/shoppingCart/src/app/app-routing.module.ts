import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import { DirectivasComponent } from './directivas/directivas.component';
import { CiclosComponent } from './ciclos/ciclos.component';
import { FormsComponent } from './forms/forms.component';
import { ProductosComponent } from './productos/productos.component';

const routes: Routes = [
  {
    path: 'productos',
    loadChildren: () => import('./productos/productos.module')
    .then(m => m.ProductosModule) //Carga diferida (Lazy Loading)
  },
  {
    path: 'cliente',
    component: ClienteComponent
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module')
    .then(m => m.AuthModule)
  },
  {
    // dominion.com/'' --> monta el componente Productos
    path: '',
    component: ProductosComponent,
  },
  {
    path: '**',
    redirectTo: 'productos'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
