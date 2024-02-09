using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AUT03_04_Rafa_Gomez.Data
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
                new IdentityRole{ Name = "Project manager", NormalizedName = "PROJECT MANAGER" },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<IdentityUser> users = new()
            {
                new () { UserName = "user@ejercicio3.com",  NormalizedUserName = "USER@EJERCICIO3.COM" },
                new () { UserName = "anotheruser@ejercicio3.com",  NormalizedUserName = "ANOTHERUSER@EJERCICIO3.COM" },
                new () { UserName = "thirduser@ejercicio3.com",  NormalizedUserName = "THIRDUSER@EJERCICIO3.COM" },
            };

            modelBuilder.Entity<IdentityUser>().HasData(users);

            var passwordHasher = new PasswordHasher<IdentityUser>();

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!");
            }

            List<IdentityUserRole<string>> userRoles = new()
            {
                new() { UserId = users[0].Id, RoleId = roles[0].Id},
                new() { UserId = users[1].Id, RoleId = roles[1].Id},
                new() { UserId = users[2].Id, RoleId = roles[2].Id},
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            
            // Importantísimo ANTES de cerrar el corchete del método
            base.OnModelCreating(modelBuilder);
        }
    }
}
