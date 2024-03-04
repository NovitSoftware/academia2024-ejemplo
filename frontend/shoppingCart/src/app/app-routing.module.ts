import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';

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
    // dominion.com/'' --> monta el componente Productos
    path: '',
    redirectTo: 'productos',
    pathMatch: 'full'
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
