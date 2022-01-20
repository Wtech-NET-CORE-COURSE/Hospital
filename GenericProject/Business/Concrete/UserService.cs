using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUnıtOfWork _unıtOfWork;
        public UserService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Users> CreateUser(Users User)
        {
            await _unıtOfWork.User.AddAsync(User);
            return User;
        }

        public async  Task DeleteUser(Users User)
        {
            _unıtOfWork.User.Remove(User);
            await _unıtOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUser()
        {
            return await _unıtOfWork.User.GetAllAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _unıtOfWork.User.GetByIdAsync(id);
        }

        public async Task UpdateUser(Users UserToBeUpdate, Users User)
        {
            UserToBeUpdate.User_Id = User.User_Id;
            await _unıtOfWork.CommitAsync();
        }
    }
}
