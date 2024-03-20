export interface Producto{
  idProducto: number;
  nombre: string;
  descripcion: string;
  imagen?: string;
  precio: number | undefined;
  stock: number | undefined ;
}

