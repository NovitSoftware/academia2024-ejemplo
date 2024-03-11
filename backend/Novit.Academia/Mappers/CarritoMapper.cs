using Mapster;
using Novit.Academia.Domain;
using Novit.Academia.Endpoints.DTO;

namespace Novit.Academia.Mappers;

public class CarritoMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CarritoDto, CarritoResponseDto>()
            .Map(des => des.IdCarrito, src => src.IdCarrito)
            .Map(des => des.Items, src => src.Items)
            .Map(des => des.Total, src => src.Items.Sum(item => item.Cantidad * item.Producto.Precio));

        config.NewConfig<ItemCarrito, ItemCarritoDto>()
           .Map(des => des.Producto, src => src.Producto)
           .Map(des => des.Cantidad, src => src.Cantidad)
           .Map(des => des.Subtotal, src => src.Subtotal());
    }
}
