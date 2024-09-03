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
    internal class LoanConfiguration : EntityConfiguration<Loan>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Loan> builder)
        {
            builder.HasOne(x => x.User)
                 .WithMany(x => x.Loans)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.LoanItems)
                .WithOne(x => x.Loan)
                .HasForeignKey(x => x.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
