using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IPrescriptionRepository:IRepository<Prescriptions>
    {
        Task<Prescriptions> GetPrescriptionsByPatientIdAsync(int id);
    }
}
