using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIMusicaAut_GomezRafa.Data
{
    public class UsersContext:IdentityDbContext<IdentityUser>
    {
        public UsersContext (DbContextOptions<UsersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // Seed data
            List<IdentityRole> roles = new()
            {
                new IdentityRole{ Name = "User", NormalizedName = "USER" },
                new IdentityRole{ Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole{ Name = "Manager", NormalizedName = "MANAGER" },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<IdentityUser> users = new()
            {
                new () { UserName = "user1@musica.com",  NormalizedUserName = "USER1@MUSICA.COM" },
                new () { UserName = "user2@musica.com",  NormalizedUserName = "USER2@MUSICA.COM" },
                new () { UserName = "user3@musica.com",  NormalizedUserName = "USER3@MUSICA.COM" },
            };

            modelBuilder.Entity<IdentityUser>().HasData(users);

            var passwordHasher = new PasswordHasher<IdentityUser>();

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!"); // Contraseña
            }

            List<IdentityUserRole<string>> userRoles = new()
            {
                new() { UserId = users[0].Id, RoleId = roles[1].Id},
                new() { UserId = users[1].Id, RoleId = roles[1].Id},
                new() { UserId = users[2].Id, RoleId = roles[2].Id},
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            // Importantísimo ANTES de cerrar el corchete del método
            base.OnModelCreating(modelBuilder);
        }
    }
}
