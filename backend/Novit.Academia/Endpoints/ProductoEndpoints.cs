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

        app.MapGet("/{idProducto}", (int idProducto) =>
        {
            return Results.Ok();
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

        app.MapPut("/{idProducto}", (int idProducto) =>
        {
            return Results.Ok();
        }).WithTags("Producto");

        app.MapDelete("/{idProducto}", (int idProducto) =>
        {
            return Results.NoContent();
        }).WithTags("Producto");
    }
}
