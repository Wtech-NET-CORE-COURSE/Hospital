using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctors>
    {
        public void Configure(EntityTypeBuilder<Doctors> builder)
        {
            builder.HasKey(w => w.Doctor_Id);
            builder.Property(w => w.Doctor_Id).UseIdentityColumn();
        }
    }
}
