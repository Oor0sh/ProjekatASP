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
    internal class BookGenreConfiguration : EntityConfiguration<BookGenre>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasOne(x => x.Genre)
                .WithMany(x => x.GenreBooks)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookGenres)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
