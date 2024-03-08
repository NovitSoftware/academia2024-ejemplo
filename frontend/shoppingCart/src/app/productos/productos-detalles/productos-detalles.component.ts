import { Component, Input, OnInit, inject, input } from '@angular/core';
import { Producto } from '../interface/producto.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productos-detalles',
  templateUrl: './productos-detalles.component.html',
  styleUrl: './productos-detalles.component.css'
})
export class ProductosDetallesComponent  {

@Input() producto!: Producto;


title: string = 'seccion productos detalle'

tieneStock():string{
  return 'red';
}

}
