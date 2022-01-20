using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PrescriptionService : IPrescriptionService
    {
        private IUnıtOfWork _unıtOfWork;
        public PrescriptionService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Prescriptions> CreatePrescription(Prescriptions Prescription)
        {
            await _unıtOfWork.Prescription.AddAsync(Prescription);
            return (Prescription);
        }

        public async Task DeletePrescription(Prescriptions Prescription)
        {
            _unıtOfWork.Prescription.Remove(Prescription);
            await _unıtOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Prescriptions>> GetAllPrescription()
        {
            return await _unıtOfWork.Prescription.GetAllAsync();
        }

        public async Task<Prescriptions> GetPrescriptionById(int id)
        {
            return await _unıtOfWork.Prescription.GetByIdAsync(id);
        }

        public async Task UpdatePrescriptionl(Prescriptions PrescriptionToBeUpdate, Prescriptions Prescription)
        {
            PrescriptionToBeUpdate.Prescriptions_Id = Prescription.Prescriptions_Id;
            await _unıtOfWork.CommitAsync();
        }
    }
}
