﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PO01_GomezRafael_v1.Data;

#nullable disable

namespace PO01_GomezRafael_v1.Migrations
{
    [DbContext(typeof(jardineriaContext))]
    partial class jardineriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.GamaProducto", b =>
                {
                    b.Property<string>("Gama")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("gama");

                    b.Property<string>("DescripcionHtml")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("descripcion_html");

                    b.Property<string>("DescripcionTexto")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("descripcion_texto");

                    b.Property<string>("Imagen")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("imagen");

                    b.HasKey("Gama")
                        .HasName("PK__gama_pro__4877EEE433A05A1C");

                    b.ToTable("gama_producto", (string)null);
                });

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.Producto", b =>
                {
                    b.Property<int>("CodigoProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_producto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoProducto"), 1L, 1);

                    b.Property<short>("CantidadEnStock")
                        .HasColumnType("smallint")
                        .HasColumnName("cantidad_en_stock");

                    b.Property<string>("Descripcion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Dimensiones")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("dimensiones");

                    b.Property<string>("Gama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("gama");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("nombre");

                    b.Property<decimal?>("PrecioProveedor")
                        .HasColumnType("numeric(15,2)")
                        .HasColumnName("precio_proveedor");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("numeric(15,2)")
                        .HasColumnName("precio_venta");

                    b.Property<string>("Proveedor")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("proveedor");

                    b.HasKey("CodigoProducto")
                        .HasName("PK__producto__105107A99D13862A");

                    b.HasIndex("Gama");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.Recomendacion", b =>
                {
                    b.Property<int>("RecomendacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecomendacionId"), 1L, 1);

                    b.Property<int>("CodigoProducto")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Estacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("ProductoCodigoProducto")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("RecomendacionId");

                    b.HasIndex("ProductoCodigoProducto");

                    b.ToTable("Recomendacion");

                    b.HasData(
                        new
                        {
                            RecomendacionId = 1,
                            CodigoProducto = 132,
                            Descripcion = "Description",
                            Estacion = "Primavera",
                            Title = "Title AR-010"
                        },
                        new
                        {
                            RecomendacionId = 2,
                            CodigoProducto = 179,
                            Descripcion = "Description Aromatica",
                            Estacion = "Primavera",
                            Title = "Title AR-009"
                        });
                });

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.Producto", b =>
                {
                    b.HasOne("PO01_GomezRafael_v1.Models.GamaProducto", "GamaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("Gama")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK__producto__gama__3D5E1FD2");

                    b.Navigation("GamaNavigation");
                });

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.Recomendacion", b =>
                {
                    b.HasOne("PO01_GomezRafael_v1.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoCodigoProducto");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PO01_GomezRafael_v1.Models.GamaProducto", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
