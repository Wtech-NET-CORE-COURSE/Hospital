using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entity.Model
{
    public class Hospitals
    {
        public Hospitals()
        {
            Doctor = new Collection<Doctors>();
            Patient = new Collection<Patients>();
        }
        public int Hospital_Id { get; set; }
        public string Hospital_Name { get; set; }
        public string Hospital_Adress { get; set; }
        public int NumberOfDoctors { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Doctors> Doctor { get; set; }
        public ICollection<Patients> Patient { get; set; }

    }
}
