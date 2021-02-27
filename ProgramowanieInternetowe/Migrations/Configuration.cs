namespace ProgramowanieInternetowe.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProgramowanieInternetowe.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProgramowanieInternetoweDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProgramowanieInternetoweDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(r => 
                r.Name,
                new IdentityRole { Name = "Administrator" },
                new IdentityRole { Name = "User" }
            );
            context.SaveChanges();
        }
    }
}
