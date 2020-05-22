using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorize.Infrastructure.Persistence.EF.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Users.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Users.User> builder)
        {
            builder.HasKey(a => a.UserName);
            builder.HasMany(r => r.Roles);
        }
    }
}
