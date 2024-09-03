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
    internal class LoanItemConfiguration : EntityConfiguration<LoanItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<LoanItem> builder)
        {
            builder.HasOne(x => x.Loan)
                .WithMany(x => x.LoanItems)
                .HasForeignKey(x => x.LoanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
