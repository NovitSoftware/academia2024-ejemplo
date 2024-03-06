import { Component, Input, input } from '@angular/core';
import { Producto } from '../interface/producto.interface';

@Component({
  selector: 'app-productos-detalles',
  templateUrl: './productos-detalles.component.html',
  styleUrl: './productos-detalles.component.css'
})
export class ProductosDetallesComponent {

@Input() producto!: Producto;

title: string = 'seccion productos detalle'

tieneStock():string{
  return 'red';
}

}
