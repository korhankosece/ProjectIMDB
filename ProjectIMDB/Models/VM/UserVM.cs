using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class UserVM
    {

        public int id { get; set; }

        [DisplayName("Username")]
        [Required/*(ErrorMessage = "The Username field is required")*/]
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
        [Required(ErrorMessage = "The EMail field is required")]
        public string email { get; set; }

        public string password { get; set; }

        //[Compare("password", ErrorMessage = "Not match")]
        //[Display(Name = "Old Password")]
        //public string oldpassword { get; set; }


        //[Display(Name = "New Password")]
        //public string newpassword { get; set; }


        //[Compare("newpassword", ErrorMessage = "Not match")]
        //[Display(Name = "Confirm Password")]
        //public string confirmpassword { get; set; }

        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }

        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;


    }
}
