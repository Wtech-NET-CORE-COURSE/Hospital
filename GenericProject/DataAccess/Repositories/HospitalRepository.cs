using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class HospitalRepository: Repository<Hospitals>,IHospitalRepository
    {
        public HospitalRepository(ProjeDbContext context) : base(context) { }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
