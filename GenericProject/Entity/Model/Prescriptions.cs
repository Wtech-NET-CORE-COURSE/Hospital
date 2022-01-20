using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model
{
    public class Prescriptions
    {
        public int Prescriptions_Id { get; set; }
        public string Medicine_Name { get; set; }
        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
