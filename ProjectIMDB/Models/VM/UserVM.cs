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
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string nationality { get; set; }

        [DisplayName("EMail")]
        [Required(ErrorMessage = "The Email field is required")]
        public string email { get; set; }


        [Required(ErrorMessage = "The password field is required")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "The confirm password field is required.")]
        [Compare("Password", ErrorMessage = "Not match")]
        [Display(Name = "Confirm Password")]
        public string confirmpassword { get; set; }

        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }

        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;


    }
}
