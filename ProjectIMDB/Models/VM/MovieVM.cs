using Microsoft.AspNetCore.Http;
using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class MovieVM
    {
        public int id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The name field is required")]
        public string name { get; set; }


        [DisplayName("Duration")]
        [Required(ErrorMessage = "The duration field is required")]
        public string duration { get; set; }


        [DisplayName("Release Date")]
        [Required(ErrorMessage = "The release date field is required")]
        public DateTime releasedate { get; set; }


        public IFormFile movieposter { set; get; }

        public string posterurl { get; set; }


        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }

        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;


        [DisplayName("Genres")]
        [Required(ErrorMessage = "Genres field is required.")]
        public List<Genre> genres { get; set; }

        public List<MovieGenre> moviegenres { get; set; }




        //public List<int> genrearray { get; set; }


        public List<MoviePerson> moviepeople { get; set; }
        public List<PersonJob> personJobs { get; set; }
        public List<Person> people { get; set; }


        //public List<Person> scenarists { get; set; }
        //public List<Person> stars { get; set; }




    }
}
