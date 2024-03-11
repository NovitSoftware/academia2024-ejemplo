using Mapster;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Repository;

namespace Novit.Academia.Service;

public interface ICarritoService
{
    List<CarritoResponseDto> GetCarritos();
    CarritoResponseDto GetCarrito(int idCarrito);
    int CreateCarrito();
    void DeleteCarrito(int idCarrito);
    void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productos);
    void RemoveProducto(int idCarrito, List<int> idProductos);
    void Checkout(int idCarrito);
}

public class CarritoService(ICarritoRepository carritoRepository) : ICarritoService
{
    public void AddProducto(int idCarrito, List<ItemCarritoProductoDto> productos)
    {
        carritoRepository.AddProducto(idCarrito, productos);
    }

    public void Checkout(int idCarrito)
    {
       carritoRepository.Checkout(idCarrito);
    }

    public int CreateCarrito()
    {
        return carritoRepository.AddCarrito();
    }

    public void DeleteCarrito(int idCarrito)
    {
        carritoRepository.RemoveCarrito(idCarrito);
    }

    public CarritoResponseDto GetCarrito(int idCarrito)
    {
        return carritoRepository.GetCarrito(idCarrito).Adapt<CarritoResponseDto>();
    }

    public List<CarritoResponseDto> GetCarritos()
    {
        var carritos = carritoRepository.GetCarritos().Adapt<List<CarritoResponseDto>>();

        //foreach (var carrito in carritos)
        //{
        //    foreach (var item in carrito.Items)
        //    {
        //        item.Subtotal = item.Cantidad * item.Producto.Precio;
        //    }

        //    carrito.Total = carrito.Items.Sum(x => x.Subtotal);
        //}

        return carritos;
    }

    public void RemoveProducto(int idCarrito, List<int> idProductos)
    {
        carritoRepository.RemoveProducto(idCarrito, idProductos);
    }
}
