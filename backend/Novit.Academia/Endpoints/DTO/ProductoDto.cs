namespace Novit.Academia.Endpoints.DTO;

public class ProductoDto
{
    public int IdProducto { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
}

public class ProductoRequestDto
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
}

public class ProductoResponseDto
{
    public int IdProducto { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public string? UrlImagen { get; set; }
    public int Stock { get; set; }
}

