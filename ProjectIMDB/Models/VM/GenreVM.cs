using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class GenreVM
    {
        public int id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The name field is required")]
        public string name { get; set; }

        public DateTime adddate { get; set; }

        public DateTime updatedate { get; set; } = DateTime.Now;

    }
}
