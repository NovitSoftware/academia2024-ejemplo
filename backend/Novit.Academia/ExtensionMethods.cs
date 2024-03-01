using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia;

public static class ExtensionMethods
{
    //public static ProductoDto ConvertToProductoDto(this Producto p)
    //{
    //    return new ProductoDto(p.Nombre,p.Descripcion,p.Precio,p.UrlImagen,p.Stock);
    //}

    public static ProductoDto ConvertToProductoDto(this Producto p) =>
        new(p.IdProducto, p.Nombre, p.Descripcion, p.Precio, p.UrlImagen, p.Stock);
}
