using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospitals>
    {
        public void Configure(EntityTypeBuilder<Hospitals> builder)
        {
            builder.HasKey(w => w.Hospital_Id);
            builder.Property(w => w.Hospital_Id).UseIdentityColumn();
        }
    }
}
