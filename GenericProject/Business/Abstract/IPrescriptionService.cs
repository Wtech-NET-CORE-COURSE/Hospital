using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescriptions>> GetAllPrescription();
        Task<Prescriptions> GetPrescriptionById(int id);
        Task<Prescriptions> CreatePrescription(Prescriptions Prescription);
        Task UpdatePrescriptionl(Prescriptions PrescriptionToBeUpdate, Prescriptions Prescription);
        Task DeletePrescription(Prescriptions Prescription);
    }
}
