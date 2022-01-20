using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PatientRepository : Repository<Patients>, IPatientRepository
    {
        public PatientRepository(ProjeDbContext context) : base(context) { }
        public async Task<Patients> GetPatientsByHospitalIdAsync(int id)
        {
            return await ProjeDbContext.Patient.Include(a => a.Hospital).SingleOrDefaultAsync();
        }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
