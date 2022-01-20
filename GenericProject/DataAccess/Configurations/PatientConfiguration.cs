using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patients>
    {
        public void Configure(EntityTypeBuilder<Patients> builder)
        {
            builder.HasKey(w => w.Patient_Id);
            builder.Property(w => w.Patient_Id).UseIdentityColumn();
            builder.Property(w => w.Patient_Condition).IsRequired();
        }
    }
}
