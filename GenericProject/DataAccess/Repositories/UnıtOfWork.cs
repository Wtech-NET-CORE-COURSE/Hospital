using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnıtOfWork : IUnıtOfWork
    {
        private ProjeDbContext _context;
        private HospitalRepository _hospitalRepository;
        private DoctorRepository _doctorRepository;
        private PatientRepository _patientRepository;
        private DateRepository _dateRepository;
        private PrescriptionRepository _prescriptionRepository;
        private PoliklinikRepository _poliklinikRepository;
        private UserRepository _userRepository;
        public UnıtOfWork(ProjeDbContext context)
        {
            this._context = context;
        }

        public IHospitalRepository Hospital => _hospitalRepository = _hospitalRepository ?? new HospitalRepository(_context);

        public IDoctorRepository Doctor => _doctorRepository = _doctorRepository ?? new DoctorRepository(_context);

        public IPoliklinikRepository Poliklinik => _poliklinikRepository = _poliklinikRepository ?? new PoliklinikRepository(_context);

        public IPatientRepository Patient => _patientRepository = _patientRepository ?? new PatientRepository(_context);

        public IDateRepository Date => _dateRepository = _dateRepository ?? new DateRepository(_context);

        public IPrescriptionRepository Prescription => _prescriptionRepository = _prescriptionRepository ?? new PrescriptionRepository(_context);

        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
