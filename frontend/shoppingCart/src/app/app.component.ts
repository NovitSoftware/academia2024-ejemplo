import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  title: string = 'ShoppingCart'
  anio: number = 2024;
  nombresDeUsuarios: string[] = ['Juancito', 'Sofia']

  // title = 'shoppingCart';

  cambiarTitulo(){
    this.title = 'MyCart'
  }

}
