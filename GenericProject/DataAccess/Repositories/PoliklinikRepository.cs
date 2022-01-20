using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class PoliklinikRepository: Repository<Polikliniks>,IPoliklinikRepository
    {
        public PoliklinikRepository(ProjeDbContext context) : base(context) { }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
