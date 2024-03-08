import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-producto-id',
  templateUrl: './producto-id.component.html',
  styleUrl: './producto-id.component.css'
})
export class ProductoIdComponent implements OnInit {

  private activatedRoute = inject(ActivatedRoute)

  productoId: number = 0;


  ngOnInit(): void {
    this.activatedRoute.paramMap
      .subscribe(params => {
        this.productoId = parseInt(params.get('id')!)
        console.log('Id de ruta: ', this.productoId);

      })


  }

}
