using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "The email field is required")]
        [Display(Name = "Email")]
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "The password field is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
