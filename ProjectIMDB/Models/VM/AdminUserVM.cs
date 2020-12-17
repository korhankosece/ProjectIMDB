using ProjectIMDB.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class AdminUserVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "The Surname field is required")]
        [Display(Name = "Surname")]
        public string surname { get; set; }

        [DisplayName("E Mail")]
        [Required(ErrorMessage = "The Email field is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password field is required")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "The confirm password field is required.")]
        [Compare("password", ErrorMessage = "Passwords Not match!!")]
        [Display(Name = "Confirm Password")]
        public string confirmpassword { get; set; }

        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }

        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;



        [DisplayName("Roles")]
        [Required(ErrorMessage = "The roles field is required.")]
        public List<string> roles { get; set; }
        public List<EnumRole> enumRoles { get; set; }

        public List<EnumRole> selectedRoles { get; set; }
    }
}
