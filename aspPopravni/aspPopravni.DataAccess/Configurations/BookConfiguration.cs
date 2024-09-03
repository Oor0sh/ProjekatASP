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
    internal class BookConfiguration : EntityConfiguration<Book>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(x => x.Description)
                 .HasMaxLength(500)
                 .IsRequired();

            builder.Property(x => x.PublicationYear)
                 .HasMaxLength(4)
                 .IsRequired();

            builder.HasOne(x => x.Author)
                    .WithMany(x => x.Books)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookGenres)
                   .WithOne(x => x.Book)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BookLibraries)
                   .WithOne(x => x.BookLB)
                   .HasForeignKey(x => x.BookId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
