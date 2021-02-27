using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProgramowanieInternetowe.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // Klasa IdentityDbContext dziedziczy z klasy DbContext dodajac rzeczy zwiazane z rejestracja i logowaniem
    public class ProgramowanieInternetoweDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProgramowanieInternetoweDbContext()
            : base("ProgramowanieInternetoweDbContext", throwIfV1Schema: false)
        {
        }

        public static ProgramowanieInternetoweDbContext Create()
        {
            return new ProgramowanieInternetoweDbContext();
        }
    }
}