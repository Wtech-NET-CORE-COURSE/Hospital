using DataAccess.Configurations;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ProjeDbContext : DbContext
    {
        public DbSet<Hospitals> Hospital { get; set; }
        public DbSet<Doctors> Doctor { get; set; }
        public DbSet<Patients> Patient { get; set; }
        public DbSet<Prescriptions> Prescription { get; set; }
        public DbSet<Dates> Date { get; set; }
        public DbSet<Polikliniks> Poliklinik { get; set; }
        public DbSet<Users> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=DESKTOP-JOE3R5V;Database=GenericProject;uid=;pwd=");
        }
        public ProjeDbContext(DbContextOptions<ProjeDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new HospitalConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new PrescriptionConfiguration());
            builder.ApplyConfiguration(new DateConfiguration());
            builder.ApplyConfiguration(new PoliklinikConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
