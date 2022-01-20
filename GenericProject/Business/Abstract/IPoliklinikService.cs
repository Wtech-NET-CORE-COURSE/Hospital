using Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IPoliklinikService
    {
        Task<IEnumerable<Polikliniks>> GetAllPoliklinik();
        Task<Polikliniks> GetPoliklinikById(int id);
        Task<Polikliniks> CreatePoliklinik(Polikliniks Poliklinik);
        Task UpdatePoliklinik(Polikliniks PoliklinikToBeUpdate, Polikliniks Poliklinik);
        Task DeletePoliklinik(Polikliniks Poliklinik);
    }
}
