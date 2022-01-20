using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class DateConfiguration : IEntityTypeConfiguration<Dates>
    {
        public void Configure(EntityTypeBuilder<Dates> builder)
        {
            builder.HasKey(w => w.Date_Id);
            builder.Property(w => w.Date_Id).UseIdentityColumn();
            builder.Property(w => w.Date_Tarih).IsRequired();
        }
    }
}
