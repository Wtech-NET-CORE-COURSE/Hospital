using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PoliklinikService : IPoliklinikService
    {
        private IUnıtOfWork _unıtOfWork;
        public PoliklinikService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Polikliniks> CreatePoliklinik(Polikliniks Poliklinik)
        {
            await _unıtOfWork.Poliklinik.AddAsync(Poliklinik);
            return (Poliklinik);
        }

        public async Task DeletePoliklinik(Polikliniks Poliklinik)
        {
            _unıtOfWork.Poliklinik.Remove(Poliklinik);
            await _unıtOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Polikliniks>> GetAllPoliklinik()
        {
            return await _unıtOfWork.Poliklinik.GetAllAsync();
        }

        public async Task<Polikliniks> GetPoliklinikById(int id)
        {
            return await _unıtOfWork.Poliklinik.GetByIdAsync(id);
        }

        public async Task UpdatePoliklinik(Polikliniks PoliklinikToBeUpdate, Polikliniks Poliklinik)
        {
            PoliklinikToBeUpdate.Poliklinik_Id = Poliklinik.Poliklinik_Id;
            await _unıtOfWork.CommitAsync();
        }
    }
}
