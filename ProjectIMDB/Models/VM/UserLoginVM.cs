using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class UserLoginVM
    {

        public int id { get; set; }

        [Required(ErrorMessage = "The name field is required")]
        [Display(Name = "Username")]
        public string username { get; set; }


        [Required(ErrorMessage = "The password field is required")]
        [Display(Name = "Password")]
        public string password { get; set; }


    }
}
