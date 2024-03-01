namespace Novit.Academia.Endpoints.DTO;

public class CarritoDto
{
    public required int IdCarrito { get; set; }

    public List<ItemCarritoDto> Items { get; set; } = [];
    
    public bool Estado { get; set; }

    public decimal Total { get; set; }
}
