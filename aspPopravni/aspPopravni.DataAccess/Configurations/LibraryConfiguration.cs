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
    internal class LibraryConfiguration : EntityConfiguration<Library>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Library> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(x => x.LibraryBooks)
                .WithOne(x => x.LibraryLB)
                .HasForeignKey(x => x.LibraryId);
        }
    }
}
