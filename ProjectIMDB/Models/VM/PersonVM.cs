﻿using ProjectIMDB.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class PersonVM
    {
        public int id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The name field is required.")]
        public string name { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "The surname field is required.")]
        public string surname { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? birthdate { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "The country field is required.")]
        public string country { get; set; }

        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }

        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;




        [DisplayName("Jobs")]
        [Required(ErrorMessage = "Jobs field is required.")]
        public List<string> jobs { get; set; }
        public List<EnumJob> enumJobs { get; set; }

        public List<EnumJob> selectedJobs { get; set; }

    }
}
