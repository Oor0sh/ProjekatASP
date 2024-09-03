using aspPopravni.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.DataAccess.Configurations
{
    public class RoleUseCaseConfiguration : EntityConfiguration<RoleUseCase>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RoleUseCase> builder)
        {
            builder.HasOne(x => x.UseCase)
                .WithMany(x => x.UseCaseRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RoleUseCases)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
