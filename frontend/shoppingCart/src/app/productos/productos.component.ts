import { Component, OnInit } from '@angular/core';
import { Producto } from './interface/producto.interface';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})

export class ProductosComponent implements OnInit {


  title: string = 'Seccion Productos';

  productos: Producto[] = [];

  ngOnInit(): void {
    console.log('Seteando array en onInit');

    this.productos = [
      {
        codigo: 'ABC123',
        nombre: 'Jabon',
        precio: undefined,
        stock: 20
      },
      {
        codigo: 'ABD123',
        nombre: 'Perfume',
        precio: 1200,
        stock: undefined
      },
      {
        codigo: 'ABG123',
        nombre: 'Desodorante',
        precio: 1200,
        stock: 20
      }

    ]
  }

  sinStock(): string {
    return 'green'
  }

}
