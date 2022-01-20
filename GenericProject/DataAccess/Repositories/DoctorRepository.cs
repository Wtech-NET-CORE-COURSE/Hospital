using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctors>, IDoctorRepository
    {
        public DoctorRepository(ProjeDbContext context) : base(context) { }
        public async Task<Doctors> GetDoctorsByHospitalIdAsync(int id)
        {
            return await ProjeDbContext.Doctor.Include(a => a.Hospital).SingleOrDefaultAsync();
        }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
