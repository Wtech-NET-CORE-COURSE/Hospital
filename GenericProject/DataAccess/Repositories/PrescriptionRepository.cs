using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PrescriptionRepository : Repository<Prescriptions>, IPrescriptionRepository
    {
        public PrescriptionRepository(ProjeDbContext context) : base(context) { }
        public async Task<Prescriptions> GetPrescriptionsByPatientIdAsync(int id)
        {
            return await ProjeDbContext.Prescription.Include(a => a.Patient).SingleOrDefaultAsync();
        }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
