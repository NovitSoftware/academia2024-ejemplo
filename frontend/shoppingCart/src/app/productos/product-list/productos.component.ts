import { Component, OnInit, inject } from '@angular/core';
import { Producto } from '../interface/producto.interface';
import { ProductoService } from '../producto.service';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css',
})
export class ProductosComponent implements OnInit {
  private productoService = inject(ProductoService);

  title: string = 'Seccion Productos';
  displayedColumns: string[] = ['nombre', 'descripcion', 'precio', 'stock'];
  productos: Producto[] = [];

  ngOnInit(): void {
    this.productoService.getProducts().subscribe({
      next: (productos) => {
        this.productos = productos;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  sinStock(): string {
    return 'green';
  }

  action(event: MatTabChangeEvent) {
    switch (event.tab.textLabel) {
      case 'res':
        console.log('Filtrar productos reservados');

        break;
      case 'can':
        console.log('Filtrar productos rechazados');

        break;
      case 'fin':
        console.log('Filtrar productos finalizados');

        break;
      default:

        break;
    }
  }
}
