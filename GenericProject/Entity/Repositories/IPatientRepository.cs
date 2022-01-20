using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IPatientRepository:IRepository<Patients>
    {
        Task<Patients> GetPatientsByHospitalIdAsync(int id);   
    }
}
