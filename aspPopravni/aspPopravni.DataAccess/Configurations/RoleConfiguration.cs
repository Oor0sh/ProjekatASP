using aspPopravni.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.DataAccess.Configurations
{
    internal class RoleConfiguration : EntityConfiguration<Role>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(20)
                  .IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Users)
                   .WithOne(x => x.Role)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.RoleUseCases)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
