using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspPopravni.Domain.Entities;

namespace aspPopravni.DataAccess.Configurations
{
    internal class LibraryBookConfiguration : EntityConfiguration<LibraryBook>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LibraryBook> builder)
        {
            builder.HasOne(x => x.LibraryLB)
                .WithMany(x => x.LibraryBooks)
                .HasForeignKey(x => x.LibraryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BookLB)
                .WithMany(x=> x.BookLibraries)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
