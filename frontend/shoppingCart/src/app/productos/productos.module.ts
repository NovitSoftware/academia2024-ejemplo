import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductosComponent } from './productos.component';
import { ProductosDetallesComponent } from './productos-detalles/productos-detalles.component';
import { RouterModule } from '@angular/router';
import { routes } from './productos-routing';
import { HomePageComponent } from './home-page/home-page.component';
import { ProductoIdComponent } from './producto-id/producto-id.component';

@NgModule({
  declarations: [
    ProductosComponent,
    ProductosDetallesComponent,
    HomePageComponent,
    ProductoIdComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [ProductosComponent, ProductosDetallesComponent]
})
export class ProductosModule { }
