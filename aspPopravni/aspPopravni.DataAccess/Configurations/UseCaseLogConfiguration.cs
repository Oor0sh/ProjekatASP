using aspPopravni.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.DataAccess.Configurations
{
    internal class UseCaseLogConfiguration : EntityConfiguration<UseCaseLog>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x => x.IsLoggedIn).IsRequired();

            builder.Property(x => x.UseCaseData)
                 .IsRequired()
                 .HasMaxLength(255);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UseCaseLogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.UseCase)
                .WithMany(x => x.UseCaseLogs)
                .HasForeignKey(x => x.UseCaseId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
