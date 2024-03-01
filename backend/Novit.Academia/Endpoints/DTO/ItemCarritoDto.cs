namespace Novit.Academia.Endpoints.DTO;

public class ItemCarritoDto
{
    public required ProductoDto Producto { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
}

public class ItemCarritoProductoDto
{
    public required int IdProducto { get; set; }
    public int Cantidad { get; set; }
}