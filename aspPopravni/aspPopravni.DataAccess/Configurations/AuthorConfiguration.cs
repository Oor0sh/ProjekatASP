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
    internal class AuthorConfiguration : EntityConfiguration<Author>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Name)
                  .HasMaxLength(50)
                  .IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Books)
                   .WithOne(x => x.Author)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
