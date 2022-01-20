using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospitals>> GetAllHospital();
        Task<Hospitals> GetHospitalById(int id);
        Task<Hospitals> CreateHospital(Hospitals Hospital);
        Task UpdateHospital(Hospitals HospitalToBeUpdate,Hospitals Hospital);
        Task DeleteHospital(Hospitals Hospital);
    }
}
