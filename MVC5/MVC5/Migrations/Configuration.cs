namespace MVC5.Migrations
{
    using Microsoft.AspNet.Identity;
    using MVC5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC5.Models.ApplicationDbContext";
        }

        protected override void Seed(MVC5.Models.ApplicationDbContext context)
        {
            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(u => u.UserName,
                 new ApplicationUser { UserName = "test@test.com", PasswordHash = hasher.HashPassword("Test123_") }
                );
        }
    }
}
