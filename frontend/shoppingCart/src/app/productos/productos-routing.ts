
import { HomePageComponent } from './home-page/home-page.component';
import { ProductoIdComponent } from './producto-id/producto-id.component';
import { ProductosComponent } from './productos.component';
import { Routes } from '@angular/router';


// -> localhost:4200/productos/

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
    children: [
      {
        path: '',
        component: ProductosComponent
      },
      {
        path: 'detalle/:id',
        component: ProductoIdComponent
      },
      {
        path: '**',
        redirectTo: 'inicio'
      }
    ]
  }
];


// Si lo quieren usar sin un template Layout

// export const routes: Routes = [
//   {
//     path: '',
//     component: ProductosComponent
//   },
//   {
//     path: 'detalle',
//     component: ProductosDetallesComponent
//   },
//   {
//     path: '**',
//     redirectTo: 'inicio'
//   }
// ];

