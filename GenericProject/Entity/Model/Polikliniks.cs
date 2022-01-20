using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entity.Model
{
    public class Polikliniks
    {
        public Polikliniks()
        {
            Doctor = new Collection<Doctors>();
        }
        public int Poliklinik_Id { get; set; }
        public string Poliklinik_Name { get; set; }
        public int NumberOfDoctors { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Doctors> Doctor { get; set; }
    }
}
