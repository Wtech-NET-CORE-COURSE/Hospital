using Business.Abstract;
using Entity.Model;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DateService : IDateService
    {
        private IUnıtOfWork _unıtOfWork;
        public DateService(IUnıtOfWork unıtOfWork)
        {
            this._unıtOfWork = unıtOfWork;
        }
        public async Task<Dates> CreateDate(Dates Date)
        {
            await _unıtOfWork.Date.AddAsync(Date);
            return Date;
        }

        public async Task DeleteDate(Dates Date)
        {
            _unıtOfWork.Date.Remove(Date);
            await _unıtOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Dates>> GetAllDates()
        {
            return await _unıtOfWork.Date.GetAllAsync();
        }

        public async Task<Dates> GetDateById(int id)
        {
            return await _unıtOfWork.Date.GetByIdAsync(id);
        }

        public async Task UpdateDate(Dates DatesToBeUpdate, Dates Date)
        {
            DatesToBeUpdate.Date_Id = Date.Date_Id;
            await _unıtOfWork.CommitAsync();
        }
    }
}
