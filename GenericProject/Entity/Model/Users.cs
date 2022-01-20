using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Model
{
    public class Users
    {
        public int User_Id { get; set; }
        public string FullName { get; set; }
        //public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
