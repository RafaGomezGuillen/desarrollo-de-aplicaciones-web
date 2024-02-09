using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PO01_GomezRafael_v1.Models;

namespace PO01_GomezRafael_v1.Data
{
    public partial class jardineriaContext : DbContext
    {
        public jardineriaContext()
        {
        }

        public jardineriaContext(DbContextOptions<jardineriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GamaProducto> GamaProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Recomendacion>? Recomendacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Recomendacion>().HasData
             (
                 new Recomendacion
                 {
                     RecomendacionId = 1,
                     Title = "Title AR-010",
                     Descripcion = "Description",
                     Estacion = "Primavera",
                     CodigoProducto = 132,
                 },
                new Recomendacion
                {
                    RecomendacionId = 2,
                    Title = "Title AR-009",
                    Descripcion = "Description Aromatica",
                    Estacion = "Primavera",
                    CodigoProducto = 179
                }
             );

            modelBuilder.Entity<GamaProducto>(entity =>
            {
                entity.HasKey(e => e.Gama)
                    .HasName("PK__gama_pro__4877EEE433A05A1C");

                entity.ToTable("gama_producto");

                entity.Property(e => e.Gama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gama");

                entity.Property(e => e.DescripcionHtml)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_html");

                entity.Property(e => e.DescripcionTexto)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_texto");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("imagen");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__105107A99D13862A");

                entity.ToTable("producto");

                entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");

                entity.Property(e => e.CantidadEnStock).HasColumnName("cantidad_en_stock");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Dimensiones)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("dimensiones");

                entity.Property(e => e.Gama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gama");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioProveedor)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("precio_proveedor");

                entity.Property(e => e.PrecioVenta)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("precio_venta");

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proveedor");

                entity.HasOne(d => d.GamaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Gama)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK__producto__gama__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
