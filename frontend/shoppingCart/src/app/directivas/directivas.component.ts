import { Component } from '@angular/core';

@Component({
  selector: 'app-directivas',
  templateUrl: './directivas.component.html',
  styleUrl: './directivas.component.css'
})
export class DirectivasComponent {

  title: string = 'Directivas';
  esVisibile: boolean = true;
  esCliente: boolean = false;
  clientesData: string[] = ['Juan', 'Edgar', 'Sofia']
  condicion: number = 7
  numeroDeColor: number = 2;
  esUsuario: boolean = false;

  jugadorN7: any = {
    name: 'Messi'
  }


  getEsCliente(): boolean {

    if (this.esCliente) {
      return true;
    }

    return false;
  }

  segunNumero(): string | null {
    switch (this.numeroDeColor) {
      case 1:
        return 'red'
      case 2:
        return 'blue'
      default:
        return null
    }
  }

  segunUsuario(): boolean {
    if(this.esUsuario){
      return true;
    }
    return false
  }




}
