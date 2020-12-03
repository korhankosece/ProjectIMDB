using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class PersonAddVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }


        [Required(ErrorMessage = "The surname field is required.")]
        public string surname { get; set; }


        [Required(ErrorMessage = "The birthdate field is required.")]
        public DateTime birthdate { get; set; }


        [Required(ErrorMessage = "The nationality field is required.")]
        public string nationality { get; set; }


       

  
     

    }
}
