﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EjerciciosEF.Models
{
    public partial class MisDatos : DbContext
    {
        public MisDatos()
        {
        }

        public MisDatos(DbContextOptions<MisDatos> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Disco> Disco { get; set; }
        public virtual DbSet<DiscoTipo> DiscoTipo { get; set; }
        public virtual DbSet<Interprete> Interprete { get; set; }
        public virtual DbSet<Puntuacion> Puntuacion { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disco>(entity =>
            {
                entity.HasKey(e => e.IdDisco)
                    .HasName("PK__Disco__581B6E77E647514E");

                entity.Property(e => e.IdDisco).ValueGeneratedNever();

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInterpreteNavigation)
                    .WithMany(p => p.Disco)
                    .HasForeignKey(d => d.IdInterprete)
                    .HasConstraintName("FK_discointerprete");
            });

            modelBuilder.Entity<DiscoTipo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdDiscoNavigation)
                    .WithMany(p => p.DiscoTipo)
                    .HasForeignKey(d => d.IdDisco)
                    .HasConstraintName("FK_discotipodisco");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.DiscoTipo)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_discotipotipo");
            });

            modelBuilder.Entity<Interprete>(entity =>
            {
                entity.HasKey(e => e.IdInterprete)
                    .HasName("PK__Interpre__5D65494BBB469C92");

                entity.Property(e => e.IdInterprete).ValueGeneratedNever();

                entity.Property(e => e.Interprete1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Interprete");
            });

            modelBuilder.Entity<Puntuacion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Iddisco).HasColumnName("iddisco");

                entity.Property(e => e.Puntuacion1).HasColumnName("Puntuacion");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Puntuacion)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK_puntuacioncliente");

                entity.HasOne(d => d.IddiscoNavigation)
                    .WithMany(p => p.Puntuacion)
                    .HasForeignKey(d => d.Iddisco)
                    .HasConstraintName("FK_puntuaciondisco");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Tipo__9E3A29A5CE28971F");

                entity.Property(e => e.IdTipo).ValueGeneratedNever();

                entity.Property(e => e.Tipo1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}