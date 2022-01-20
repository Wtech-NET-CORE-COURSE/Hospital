using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetAllUser();
        Task<Users> GetUserById(int id);
        Task<Users> CreateUser(Users User);
        Task UpdateUser(Users UserToBeUpdate, Users User);
        Task DeleteUser(Users User);
    }
}
