using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonelManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelManagement.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(200);

            builder.Property(x => x.SurName).IsRequired(true);
            builder.Property(x => x.SurName).HasMaxLength(200);

            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(200);


            builder.HasIndex(x => x.UserName).IsUnique(true);
            builder.Property(x => x.UserName).HasMaxLength(200);
            builder.Property(x => x.UserName).IsRequired(true);

            builder.Property(x => x.AppRoleId).IsRequired(true);

            builder.HasMany(x => x.Tasks).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
            builder.HasMany(x => x.Notifications).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
        }
    }
}
