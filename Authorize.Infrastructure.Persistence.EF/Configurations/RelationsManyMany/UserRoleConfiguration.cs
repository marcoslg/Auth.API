using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorize.Infrastructure.Persistence.EF.Configurations.RelationsManyMany
{
      public class UserRoleConfiguration : IEntityTypeConfiguration<Domain.Relations.UserRole>
    {
        public void Configure(EntityTypeBuilder<Domain.Relations.UserRole> builder)
        {
            builder.Property<string>("Username");
            builder.Property<string>("RoleName");
            builder.HasKey("RoleName", "Username");
            builder.HasOne(a => a.User)
                .WithMany(a=>a.Roles)
                .HasForeignKey("Username");
            builder.HasOne(a => a.Role)
                .WithMany(a=>a.Users)
                .HasForeignKey("RoleName");
        }
    }
}
