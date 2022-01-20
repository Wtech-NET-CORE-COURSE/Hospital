using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.TokenModels
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expration { get; set; } //kullanıcının token aldığı saati tutar.
        public string ResfreshToken { get; set; }
    
    }
}
