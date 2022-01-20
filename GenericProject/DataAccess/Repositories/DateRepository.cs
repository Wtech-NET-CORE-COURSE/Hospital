using Entity.Model;
using Entity.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DateRepository : Repository<Dates>, IDateRepository
    {
        public DateRepository(ProjeDbContext context) : base(context) { }
        public async Task<Dates> GetDatesByDoctorIdAsync(int id)
        {
            return await ProjeDbContext.Date.Include(a => a.Doctor).SingleOrDefaultAsync();
        }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
