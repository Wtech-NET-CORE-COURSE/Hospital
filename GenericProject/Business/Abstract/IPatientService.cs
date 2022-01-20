using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IPatientService
    {
        Task<IEnumerable<Patients>> GetAllPatient();
        Task<Patients> GetPatientById(int id);
        Task<Patients> CreatePatient(Patients Patient);
        Task UpdatePatient(Patients PatientToBeUpdate, Patients Patient);
        Task DeletePatient(Patients Patient);
    }
}
