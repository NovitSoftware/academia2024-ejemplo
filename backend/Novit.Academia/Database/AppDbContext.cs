using Microsoft.EntityFrameworkCore;
using Novit.Academia.Domain;

namespace Novit.Academia.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //Forma clasica contructor
    //public AppDbContext(DbContextOptions<AppDbContext> options)
    //   : base(options)
    //{

    //}
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ItemCarrito> Items { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
}
