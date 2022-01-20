using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repositories
{
    public interface IUnıtOfWork:IDisposable
    {
        IHospitalRepository Hospital { get; }
        IDoctorRepository Doctor { get; }
        IPoliklinikRepository Poliklinik { get; }
        IPatientRepository Patient { get; }
        IDateRepository Date { get; }
        IPrescriptionRepository Prescription { get; }
        IUserRepository User { get; }

        Task<int> CommitAsync();
    }
}
