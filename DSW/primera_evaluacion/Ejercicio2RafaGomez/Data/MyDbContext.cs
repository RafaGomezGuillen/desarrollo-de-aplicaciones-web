using Ejercicio2RafaGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2RafaGomez.Data
{
    public partial class MyDbContext:DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Game>? Game { get; set; }
        public DbSet<Genre>? Genre { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<Genre>().HasData
            (
                new Genre { Id = 1, Name = "Shooter" },
                new Genre { Id = 2, Name = "RPG" }
            );

            modelBuilder.Entity<Game>().HasData
            (
                new Game { Id = 1, Title = "Doom", GenreId = 1 },
                new Game { Id = 2, Title = "Final Fantasy", GenreId = 2 }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}
