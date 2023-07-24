using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucrture.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext( DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);
        //      builder.Entity<AppUser>()
        // .HasOne(e => e.Address)
        // .WithOne(e => e.AppUser)
        // .HasForeignKey<Address>(e => e.AppUserId)
        // .IsRequired();

        }
    }
}