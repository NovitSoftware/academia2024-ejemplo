using Carter;
using Microsoft.AspNetCore.Mvc;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Service;

namespace Novit.Academia.Endpoints;

public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Carrito");

        app.MapGet("/", (ICarritoService carritoService) =>
        {
            var carritosDto = carritoService.GetCarritos();

            return Results.Ok(carritosDto);
        }).WithTags("Carrito");

        app.MapGet("/{idCarrito:int}", (ICarritoService carritoService, int idCarrito) =>
        {
            var carritoDto = carritoService.GetCarrito(idCarrito);

            return Results.Ok(carritoDto);
        }).WithTags("Carrito");

        app.MapPost("/", (ICarritoService carritoService) => 
        {
            int idCarrito = carritoService.CreateCarrito();

            return Results.Ok(idCarrito);
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}", (ICarritoService carritoService, int idCarrito) => 
        {
            carritoService.DeleteCarrito(idCarrito);

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/{idCarrito:int}/Producto", (ICarritoService carritoService, int idCarrito, [FromBody] List<ItemCarritoProductoDto> productos) =>
        {
            carritoService.AddProducto(idCarrito, productos);

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}/Producto", (ICarritoService carritoService, int idCarrito, [FromBody] List<int> idProductos) => 
        {
            carritoService.RemoveProducto(idCarrito, idProductos);

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/{idCarrito:int}/Checkout", (ICarritoService carritoService, int idCarrito) => 
        {
            carritoService.Checkout(idCarrito);

            return Results.Ok();
        }).WithTags("Carrito");
    }
}
