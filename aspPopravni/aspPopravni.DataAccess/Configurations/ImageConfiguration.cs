using aspPopravni.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspPopravni.DataAccess.Configurations
{
    internal class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Source).IsRequired();
        }
    }
}
