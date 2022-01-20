using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entity.Model
{
   public class Doctors
    { 
        public Doctors()
        {
            Date = new Collection<Dates>();
            Prescription = new Collection<Prescriptions>();
        }
        
        public int Doctor_Id { get; set; }
        public string Doctor_Name{ get; set; }
        public Hospitals Hospital { get; set; }
        public Polikliniks Poliklinik { get; set; }
        public ICollection<Dates> Date { get; set; }
        public ICollection<Prescriptions> Prescription { get; set; }
        public bool IsActıve { get; set; }
    }
}
