using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PatientService : IPatientService
    {
        private IUnıtOfWork _unıtOfWork;
        public PatientService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Patients> CreatePatient(Patients Patient)
        {
            await _unıtOfWork.Patient.AddAsync(Patient);
            return Patient;
        }

        public async Task DeletePatient(Patients Patient)
        {
            _unıtOfWork.Patient.Remove(Patient);
            await _unıtOfWork.CommitAsync();

        }

        public async Task<IEnumerable<Patients>> GetAllPatient()
        {
            return await _unıtOfWork.Patient.GetAllAsync();
        }

        public async Task<Patients> GetPatientById(int id)
        {
            return await _unıtOfWork.Patient.GetByIdAsync(id);
        }

        public async Task UpdatePatient(Patients PatientToBeUpdate, Patients Patient)
        {
            PatientToBeUpdate.Patient_Condition = Patient.Patient_Condition;
            await _unıtOfWork.CommitAsync();
        }
    }
}
