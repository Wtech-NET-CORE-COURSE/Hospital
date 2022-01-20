using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDateService
    {
        Task<IEnumerable<Dates>> GetAllDates();
        Task<Dates> GetDateById(int id);
        Task<Dates> CreateDate(Dates Date);
        Task UpdateDate(Dates DatesToBeUpdate, Dates Date);
        Task DeleteDate(Dates Date);
    }
}
