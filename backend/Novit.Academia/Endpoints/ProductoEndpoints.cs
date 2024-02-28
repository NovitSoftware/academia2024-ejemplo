using Carter;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Endpoints;

public class ProductoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Producto");

        app.MapGet("/", (AppDbContext context) =>
        {
            var productos = context.Productos.Select(p => p.ConvertToProductoDto());
            
            return Results.Ok(productos);

        }).WithTags("Producto");

        app.MapGet("/{idProducto}", (AppDbContext context, int idProducto) =>
        {
            var productos = context.Productos.Where(p => p.IdProducto == idProducto).Select(p => p.ConvertToProductoDto());

            return Results.Ok(productos);
        }).WithTags("Producto");

        app.MapPost("/", (AppDbContext context, ProductoDto productoDto) =>
        {
            Producto producto = new Producto
            { 
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio,
                UrlImagen = productoDto.UrlImagen,
                Descripcion = productoDto.Descripcion,
                Stock = productoDto.Stock
            };

            context.Productos.Add(producto);

            context.SaveChanges();

            return Results.Created();
        }).WithTags("Producto");

        app.MapPut("/{idProducto}", (AppDbContext context, int idProducto, ProductoDto productoDto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
                return Results.BadRequest();

            producto.Nombre = productoDto.Nombre;
            producto.Precio = productoDto.Precio;
            producto.Descripcion = productoDto.Descripcion;
            producto.Stock = productoDto.Stock;
            producto.UrlImagen = productoDto.UrlImagen;

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Producto");

        app.MapDelete("/{idProducto}", (AppDbContext context, int idProducto) =>
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
                return Results.BadRequest();

            context.Productos.Remove(producto);

            context.SaveChanges();

            return Results.NoContent();
        }).WithTags("Producto");
    }
}
