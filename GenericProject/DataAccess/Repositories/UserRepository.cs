using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
  public class UserRepository: Repository<Users>,IUserRepository
    {
        public UserRepository(ProjeDbContext context) : base(context) { }
        private ProjeDbContext ProjeDbContext
        {
            get { return Context as ProjeDbContext; }
        }
    }
}
