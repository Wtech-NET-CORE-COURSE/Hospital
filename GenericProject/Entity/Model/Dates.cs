using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model
{
    public class Dates
    {
        public int Date_Id { get; set; }
        public DateTime Date_Tarih{ get; set; }
        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
