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
    internal class GenreConfiguration : EntityConfiguration<Genre>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Genre> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name)
                  .HasMaxLength(20)
                  .IsRequired();

            builder.HasMany(x => x.GenreBooks)
                   .WithOne(x => x.Genre)
                   .HasForeignKey(x => x.GenreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
