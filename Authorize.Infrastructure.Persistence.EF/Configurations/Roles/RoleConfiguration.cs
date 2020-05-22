using Authorize.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authorize.Infrastructure.Persistence.EF.Configurations.Roles
{
    public class RoleConfiguration : IEntityTypeConfiguration<Domain.Roles.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Roles.Role> builder)
        {
            builder.HasKey(a => a.Name);

            builder.Property(a => a.Description)
                .HasMaxLength(200);

            builder.HasMany(r => r.Applications);
            builder.HasMany(r => r.Users);
        }
    }
}
