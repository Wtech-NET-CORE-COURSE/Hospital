using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctors>> GetAllDoctor();
        Task<Doctors> GetDoctorById(int id);
        Task<Doctors> CreateDoctor(Doctors Doctor);
        Task UpdateDoctor(Doctors DoctorToBeUpdate, Doctors Doctor);
        Task DeleteDoctor(Doctors Doctor);
    }
}
