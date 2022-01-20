using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HospitalService:IHospitalService
    {
        private IUnıtOfWork _unıtOfWork;
        public HospitalService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async  Task<IEnumerable<Hospitals>> GetAllHospital()
        {
           return await _unıtOfWork.Hospital.GetAllAsync();

        }

        public async Task<Hospitals> GetHospitalById(int id)
        {
            return await _unıtOfWork.Hospital.GetByIdAsync(id);
        }

        public async Task<Hospitals> CreateHospital(Hospitals Hospital)
        {
            await _unıtOfWork.Hospital.AddAsync(Hospital);
            return Hospital;
        }

        public async  Task UpdateHospital(Hospitals HospitalToBeUpdate, Hospitals Hospital)
        {
            HospitalToBeUpdate.Hospital_Name = Hospital.Hospital_Name;
            await _unıtOfWork.CommitAsync();
        }

        public async Task DeleteHospital(Hospitals Hospital)
        {
            _unıtOfWork.Hospital.Remove(Hospital);
            await _unıtOfWork.CommitAsync();
        }

    }
}
