using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entity.Model
{
    public class Patients
    {
        public Patients()
        {
            Date = new Collection<Dates>();
            Prescription = new Collection<Prescriptions>();
        }
        public int Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Condition { get; set; }
        public Hospitals Hospital { get; set; }
        public ICollection<Dates> Date { get; set; }
        public ICollection<Prescriptions> Prescription { get; set; }
        public bool IsActive { get; set; }
    }
}
