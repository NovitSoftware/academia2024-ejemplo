using Mapster;
using Microsoft.EntityFrameworkCore;
using Novit.Academia.Database;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Repository;

public interface ICarritoRepository
{
    List<CarritoDto> GetCarritos();
    CarritoDto GetCarrito(int idCarrito);
    int AddCarrito();
    void RemoveCarrito(int idCarrito);
    void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productos);
    void RemoveProducto(int idCarrito, List<int> idProductos);
    void Checkout(int idCarrito);
}

public class CarritoRepository(AppDbContext context) : ICarritoRepository
{
    public int AddCarrito()
    {
        var carrito = new Carrito();  

        context.Carritos.Add(carrito);

        context.SaveChanges();

        return carrito.IdCarrito;
    }

    public void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productosDtos)
    {
        var carrito = context.Carritos.Single(x => x.IdCarrito == idCarrito);

        foreach (var productoDto in productosDtos)
        {
            var producto = context.Productos.FirstOrDefault(x => x.IdProducto == productoDto.IdProducto);

            var itemCarrito = new ItemCarrito { Carrito = carrito, Producto = producto, Cantidad = productoDto.Cantidad };

            carrito.Items.Add(itemCarrito);
        }

        context.SaveChanges();
    }

    public void Checkout(int idCarrito)
    {
        var carrito = context.Carritos.Where(x => x.IdCarrito == idCarrito)
                .Include(x => x.Items)
                .ThenInclude(x => x.Producto)
                .FirstOrDefault();

        if (carrito == null)
            throw new Exception($"IdCarrito {idCarrito} no existe");

        foreach (var item in carrito.Items)
        {
            var producto = context.Productos.FirstOrDefault(x => x.IdProducto == item.Producto.IdProducto);

            if (producto == null)
                throw new Exception($"IdProducto {item.Producto.IdProducto} no existe");

            if (producto.Stock >= item.Cantidad)
                producto.Stock = producto.Stock - item.Cantidad;
            else
                throw new Exception($"IdProducto {item.Producto.IdProducto} no hay suficiente stock");
        }

        carrito.Estado = false;

        context.SaveChanges();
    }

    public CarritoDto GetCarrito(int idCarrito)
    {
        var carrito = context.Carritos
            .Where(x => x.IdCarrito == idCarrito && x.Estado == true)
            .Include(x => x.Items)
            .ThenInclude(x => x.Producto)
            .FirstOrDefault();

        return carrito.Adapt<CarritoDto>();
    }

    public List<CarritoDto> GetCarritos()
    {
        var carritos = context.Carritos
                .Where(x => x.Estado == true)
                .Include(x => x.Items)
                .ThenInclude(x => x.Producto)
                .ToList();

        return carritos.Adapt<List<CarritoDto>>();
    }

    public void RemoveCarrito(int idCarrito)
    {
        var carrito = context.Carritos.FirstOrDefault(x => x.IdCarrito == idCarrito);

        if (carrito == null)
            throw new Exception($"IdCarrito {idCarrito} no existe");

        context.Carritos.Remove(carrito);

        context.SaveChanges();
    }

    public void RemoveProducto(int idCarrito, List<int> idProductos)
    {
        var carrito = context.Carritos.Single(x => x.IdCarrito == idCarrito);

        if (carrito == null)
            throw new Exception($"IdCarrito {idCarrito} no existe");

        foreach (var idProducto in idProductos)
        {
            var producto = context.Productos.FirstOrDefault(x => x.IdProducto == idProducto);

            if (producto == null)
                throw new Exception($"IdProducto {idProducto} no existe");

            var itemCarrito = context.Items
                .FirstOrDefault(x => x.Carrito.IdCarrito == carrito.IdCarrito &&
                    x.Producto.IdProducto == producto.IdProducto);

            carrito.Items.Remove(itemCarrito);
        }

        context.SaveChanges();
    }
}
