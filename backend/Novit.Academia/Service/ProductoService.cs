using Mapster;
using Novit.Academia.Endpoints.DTO;
using Novit.Academia.Repository;

namespace Novit.Academia.Service;

public interface IProductoService
{
    List<ProductoResponseDto> GetProductos();
    ProductoResponseDto GetProducto(int idProducto);
    void CreateProducto(ProductoRequestDto productoDto);
    int UpdateProducto(int idProducto, ProductoRequestDto productoDto);
    void DeleteProducto(int idProducto);
}

public class ProductoService(IProductoRepository productoRepository) : IProductoService
{
    public void CreateProducto(ProductoRequestDto productoDto)
    {
        productoRepository.AddProducto(productoDto.Adapt<ProductoDto>());
    }

    public void DeleteProducto(int idProducto)
    {
        productoRepository.RemoveProducto(idProducto);
    }

    public ProductoResponseDto GetProducto(int idProducto)
    {
        return productoRepository.GetProducto(idProducto).Adapt<ProductoResponseDto>();
    }

    public List<ProductoResponseDto> GetProductos()
    {
        return productoRepository.GetProductos().Adapt<List<ProductoResponseDto>>();
    }

    public int UpdateProducto(int idProducto, ProductoRequestDto productoDto)
    {
        return productoRepository.UpdateProducto(idProducto, productoDto.Adapt<ProductoDto>());
    }
}
