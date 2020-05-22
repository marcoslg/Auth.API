using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorize.Infrastructure.Persistence.EF.Configurations.Roles
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<Domain.Roles.ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<Domain.Roles.ApplicationRole> builder)
        {
            builder.OwnsMany(a => a.Permisions);
        }
    }
}
