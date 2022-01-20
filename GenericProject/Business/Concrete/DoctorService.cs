using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoctorService : IDoctorService
    {
        private IUnıtOfWork _unıtOfWork;
        public DoctorService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Doctors> CreateDoctor(Doctors Doctor)
        {
            await _unıtOfWork.Doctor.AddAsync(Doctor);
            await _unıtOfWork.CommitAsync();
            return Doctor;
        }

        public async Task DeleteDoctor(Doctors Doctor)
        {
            _unıtOfWork.Doctor.Remove(Doctor);
            await _unıtOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Doctors>> GetAllDoctor()
        {
            return await _unıtOfWork.Doctor.GetAllAsync();
        }

        public async Task<Doctors> GetDoctorById(int id)
        {
            return await _unıtOfWork.Doctor.GetByIdAsync(id);
        }

        public async Task UpdateDoctor(Doctors DoctorToBeUpdate, Doctors Doctor)
        {
            DoctorToBeUpdate.Doctor_Name = Doctor.Doctor_Name;
            await _unıtOfWork.CommitAsync();
        }
    }
}
