using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PoliklinikConfiguration : IEntityTypeConfiguration<Polikliniks>
    {
        public void Configure(EntityTypeBuilder<Polikliniks> builder)
        {
            builder.HasKey(w => w.Poliklinik_Id);
            builder.Property(w => w.Poliklinik_Id).UseIdentityColumn();
        }
    }
}
