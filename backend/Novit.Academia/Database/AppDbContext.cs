using Microsoft.EntityFrameworkCore;
using Novit.Academia.Domain;
using System.Data;

namespace Novit.Academia.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ItemCarrito> Items { get; set; }
    public DbSet<Carrito> Carritos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }

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
        modelBuilder.Entity<Rol>().HasData(
           new Rol
           {
               Id = Guid.NewGuid(),
               Name = "administrador"
           },
           new Rol
           {
               Id = Guid.NewGuid(),
               Name = "cliente"
           },
           new Rol
           {
               Id = Guid.NewGuid(),
               Name = "vendedor"
           }
           );
    }
}
