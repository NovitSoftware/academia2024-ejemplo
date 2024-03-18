using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Novit.Academia.Domain;

[Table("Rol")]
public class Rol
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public List<Usuario> Usuarios { get; } = [];
}
