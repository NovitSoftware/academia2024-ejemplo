﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novit.Academia.Database;

#nullable disable

namespace Novit.Academia.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240228221150_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Novit.Academia.Domain.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCarrito");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("Novit.Academia.Domain.ItemCarrito", b =>
                {
                    b.Property<int>("IdItemCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCarrito")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdItemCarrito");

                    b.HasIndex("IdCarrito");

                    b.HasIndex("IdProducto");

                    b.ToTable("ItemCarrito");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            IdProducto = 1,
                            Nombre = "Lavandina",
                            Precio = 1000m,
                            Stock = 100
                        },
                        new
                        {
                            IdProducto = 2,
                            Nombre = "Detergente",
                            Precio = 750m,
                            Stock = 43
                        },
                        new
                        {
                            IdProducto = 3,
                            Nombre = "Esponja",
                            Precio = 200m,
                            Stock = 2340
                        });
                });

            modelBuilder.Entity("Novit.Academia.Domain.ItemCarrito", b =>
                {
                    b.HasOne("Novit.Academia.Domain.Carrito", "Carrito")
                        .WithMany("Items")
                        .HasForeignKey("IdCarrito")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Novit.Academia.Domain.Producto", "Producto")
                        .WithMany("Items")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Carrito", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Novit.Academia.Domain.Producto", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}