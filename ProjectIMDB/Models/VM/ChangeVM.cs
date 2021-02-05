using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class ChangeVM
    {

        public int id { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Surname")]
        public string surname { get; set; }

        [DisplayName("Birthdate")]
        public DateTime birthdate { get; set; }

        [DisplayName("Country")]
        public string country { get; set; }

        [DisplayName("EMail")]
        public string email { get; set; }

        public string password { get; set; }

        // [Compare("password", ErrorMessage = "Not match")]
        [DisplayName("Old Password")]
        public string oldpassword { get; set; }

    }
}
