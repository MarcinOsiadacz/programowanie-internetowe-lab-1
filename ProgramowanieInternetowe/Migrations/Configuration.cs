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
            // Dodaje wymagane Role automatycznie po wykonaniu migracji
            context.Roles.AddOrUpdate(r => 
                r.Name,
                new IdentityRole { Name = "Administrator" },
                new IdentityRole { Name = "User" }
            );
            context.SaveChanges();
        }
    }
}
