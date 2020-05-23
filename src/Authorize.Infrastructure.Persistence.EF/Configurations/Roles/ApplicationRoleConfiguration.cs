using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorize.Infrastructure.Persistence.EF.Configurations.Roles
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<Domain.Roles.ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<Domain.Roles.ApplicationRole> builder)
        {
            builder.Property<string>("RoleName");
            builder.Property<string>("AppName");

            builder.HasKey("RoleName", "AppName");
            builder.HasOne(ar => ar.Application)
                .WithMany()
                .HasForeignKey("AppName");

            builder.OwnsMany(a => a.Permisions).ToTable("RolePermisions");
        }
    }
}
