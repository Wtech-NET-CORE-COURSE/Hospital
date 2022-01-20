using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescriptions>
    {
        public void Configure(EntityTypeBuilder<Prescriptions> builder)
        {
            builder.HasKey(w => w.Prescriptions_Id);
            builder.Property(w => w.Prescriptions_Id).UseIdentityColumn();
            builder.Property(w => w.Medicine_Name).IsRequired();
        }
    }
}
