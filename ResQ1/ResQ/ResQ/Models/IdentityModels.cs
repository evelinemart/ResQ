using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResQ.Models
{    
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string UserLastName { set; get; }
        [Required]
        public string UserFirstName { set; get; }
        public ICollection<Request> Requests { set; get; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<HelpInfo> Informations { set; get; }
        public DbSet<Location> Locations { set; get; }
        public DbSet<FireStation> FireStations { set; get; }
        public DbSet<Request> Requests { set; get; }

    }
}