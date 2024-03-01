using Carter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Endpoints;

public class CarritoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routes)
    {
        var app = routes.MapGroup("/api/Carrito");

        app.MapGet("/", (AppDbContext context) =>
        {
            var carritos = context.Carritos
                .Where(x => x.Estado == true)
                .Include(x => x.Items)
                .ThenInclude(x => x.Producto)
                .ToList();

            List<CarritoDto> carritosDto = [];

            foreach(var carrito in carritos)
            {
                var carritoDto = new CarritoDto { IdCarrito = carrito.IdCarrito };

                carritoDto.Items = new List<ItemCarritoDto>();

                foreach (var item in carrito.Items)
                {
                    var productoDto = item.Producto.ConvertToProductoDto();

                    var itemCarritoDto = new ItemCarritoDto { 
                        Producto = productoDto, 
                        Cantidad = item.Cantidad, 
                        Subtotal = item.Subtotal() 
                    };

                    carritoDto.Items.Add(itemCarritoDto);
                }

                carritosDto.Add(carritoDto);

                carritoDto.Total = carrito.Total();
            }

            return Results.Ok(carritosDto);
        }).WithTags("Carrito");

        app.MapGet("/{idCarrito:int}", (AppDbContext context, int idCarrito) =>
        {
            var carrito = context.Carritos
                .Where(x => x.IdCarrito == idCarrito && x.Estado == true)
                .Include(x => x.Items)
                .ThenInclude(x => x.Producto)
                .FirstOrDefault();

            if (carrito == null)
                return Results.BadRequest($"IdCarrito {idCarrito} no existe");

            List<CarritoDto> carritosDto = [];

            var carritoDto = new CarritoDto { IdCarrito = carrito.IdCarrito };

            carritoDto.Items = new List<ItemCarritoDto>();

            carritoDto.Estado = carrito.Estado;

            foreach (var item in carrito.Items)
            {
                var productoDto = item.Producto.ConvertToProductoDto();

                var itemCarritoDto = new ItemCarritoDto
                {
                    Producto = productoDto,
                    Cantidad = item.Cantidad,
                    Subtotal = item.Subtotal()
                };

                carritoDto.Items.Add(itemCarritoDto);
            }

            carritosDto.Add(carritoDto);

            carritoDto.Total = carrito.Total();

            return Results.Ok(carritoDto);
        }).WithTags("Carrito");

        app.MapPost("/", (AppDbContext context) => 
        {
            context.Carritos.Add(new Carrito());

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}", (AppDbContext context, int idCarrito) => 
        {
            var carrito = context.Carritos.FirstOrDefault(x => x.IdCarrito == idCarrito);

            if (carrito == null)
                return Results.BadRequest($"IdCarrito {idCarrito} no existe");

            context.Carritos.Remove(carrito);

            context.SaveChanges();

            return Results.Ok();

        }).WithTags("Carrito");

        app.MapPost("/{idCarrito:int}/Producto", (AppDbContext context, int idCarrito, List<ItemCarritoProductoDto> productos) =>
        {
            var carrito = context.Carritos.FirstOrDefault(x => x.IdCarrito == idCarrito);

            if (carrito == null)
                return Results.BadRequest($"IdCarrito {idCarrito} no existe");

            foreach(var itemCarritoProducto in productos)
            {
                var producto = context.Productos.FirstOrDefault(x => x.IdProducto == itemCarritoProducto.IdProducto);

                if (producto == null)
                    return Results.BadRequest($"IdProducto {itemCarritoProducto.IdProducto} no existe");

                carrito.Items.Add(new ItemCarrito { 
                    Carrito = carrito, 
                    Producto = producto, 
                    Cantidad = itemCarritoProducto.Cantidad 
                });
            }

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapDelete("/{idCarrito}/Producto", (AppDbContext context, int idCarrito, [FromBody] List<int> idProductos) => 
        {
            var carrito = context.Carritos.FirstOrDefault(x => x.IdCarrito == idCarrito);

            if (carrito == null)
                return Results.BadRequest($"IdCarrito {idCarrito} no existe");

            foreach (var idProducto in idProductos)
            {
                var producto = context.Productos.FirstOrDefault(x => x.IdProducto == idProducto);

                if (producto == null)
                    return Results.BadRequest($"IdProducto {idProducto} no existe");

                var itemCarrito = context.Items
                    .FirstOrDefault(x => x.Carrito.IdCarrito == carrito.IdCarrito &&
                        x.Producto.IdProducto == producto.IdProducto);

                carrito.Items.Remove(itemCarrito);
            }

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Carrito");

        app.MapPost("/{idCarrito:int}/Checkout", (AppDbContext context, int idCarrito) => 
        {
            var carrito = context.Carritos.Where(x => x.IdCarrito == idCarrito)
                .Include(x => x.Items)
                .ThenInclude(x => x.Producto)
                .FirstOrDefault();

            if (carrito == null)
                return Results.BadRequest($"IdCarrito {idCarrito} no existe");

            foreach (var item in carrito.Items)
            {
                var producto = context.Productos.FirstOrDefault(x => x.IdProducto == item.Producto.IdProducto);

                if (producto == null)
                    return Results.BadRequest($"IdProducto {item.Producto.IdProducto} no existe");

                if (producto.Stock >= item.Cantidad)
                    producto.Stock = producto.Stock - item.Cantidad;
                else
                    return Results.BadRequest($"IdProducto {item.Producto.IdProducto} no hay suficiente stock");
            }

            carrito.Estado = false;

            context.SaveChanges();

            return Results.Ok();
        }).WithTags("Carrito");
    }
}
