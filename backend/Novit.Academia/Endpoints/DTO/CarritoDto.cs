namespace Novit.Academia.Endpoints.DTO;

public class CarritoDto
{
    public required int IdCarrito { get; set; }

    public List<ItemCarritoDto> Items { get; set; } = [];

    public decimal Total { get; set; }

    public bool Estado { get; set; }
}

public class CarritoResponseDto
{
    public required int IdCarrito { get; set; }

    public List<ItemCarritoDto> Items { get; set; } = [];

    public decimal Total { get; set; }

    public bool Estado { get; set; }
}

public class CarritoRequestDto
{
    public required int IdCarrito { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }
}
