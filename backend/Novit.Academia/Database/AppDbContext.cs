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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                IdProducto = 1,
                Nombre = "Lavandina",
                Precio = 1000,
                Stock = 100
            },
            new Producto
            {
                IdProducto = 2,
                Nombre = "Detergente",
                Precio = 750,
                Stock = 43
            },
            new Producto
            {
                IdProducto = 3,
                Nombre = "Esponja",
                Precio = 200,
                Stock = 2340
            }
            );
    }
}
