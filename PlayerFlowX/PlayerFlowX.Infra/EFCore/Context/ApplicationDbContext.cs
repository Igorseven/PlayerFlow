using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayerFlowX.Domain.Identity;
using System;

namespace PlayerFlowX.Infra.EFCore.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, 
        IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext)
            : base(dbContext)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
