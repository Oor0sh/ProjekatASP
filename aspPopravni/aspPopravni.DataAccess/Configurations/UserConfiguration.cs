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
    internal class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(255);

            builder.HasMany(x => x.Loans)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Role)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UseCaseLogs)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
