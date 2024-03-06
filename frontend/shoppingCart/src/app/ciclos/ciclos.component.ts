import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-ciclos',
  templateUrl: './ciclos.component.html',
  styleUrl: './ciclos.component.css'
})

export class CiclosComponent implements OnInit, AfterViewInit {

  @ViewChild('AfterViewInit') elementRef!: ElementRef

  ngAfterViewInit(): void {
    console.log(this.elementRef.nativeElement.style.color = 'red');

  }

  productos: string[] = [];

  ngOnInit(): void {
    console.log('Se inicio el ngOnInit');
    console.log('------');
    console.log('productos: ', this.productos);
    //Servicio
    this.productos = ['A123', 'B123']
    console.log('productos: ', this.productos);

    this.ultimosProductos();
  }

  ultimosProductos() {

  }

}
