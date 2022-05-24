using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerFlowX.Domain.Identity;

namespace PlayerFlowX.Infra.EFCore.EntitiesMapping
{
    public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.User).WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.UserId).IsRequired();

            builder.HasOne(ur => ur.Role).WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.RoleId).IsRequired();



            //builder.HasMany(u => u.Roles)
            //   .WithMany(r => r.Users)
            //   .UsingEntity<Dictionary<string, object>>("UserRole",
            //       ur => ur.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
            //       ur => ur.HasOne<User>().WithMany().HasForeignKey("UserId")
            //       );
        }
    }
}
