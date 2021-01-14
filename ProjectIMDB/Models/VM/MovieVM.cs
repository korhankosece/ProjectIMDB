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
        [DisplayName("Movie Poster")]
        public IFormFile movieposter { set; get; }
        public string posterurl { get; set; }
        [DisplayName("Movie Images")]
        public List<IFormFile> movieImages { set; get; }
        public List<string> imagepaths { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The description field is required")]
        public string description { get; set; }

        [DisplayName("Add Date")]
        public DateTime adddate { get; set; }
        [DisplayName("Update Date")]
        public DateTime updatedate { get; set; } = DateTime.Now;




        [DisplayName("Genres")]
        [Required(ErrorMessage = "Genres field is required.")]
        public List<Genre> genres { get; set; }
        public List<MovieGenre> moviegenres { get; set; }




        public List<MoviePerson> moviepeople { get; set; }
        public List<PersonJob> personJobs { get; set; }



        [DisplayName("Directors")]
        [Required(ErrorMessage = "Directors field is required")]
        public List<int> directorarray { get; set; }
        [DisplayName("Scenarists")]
        [Required(ErrorMessage = "Scenarists field is required")]
        public List<int> scenaristarray { get; set; }
        [DisplayName("Stars")]
        [Required(ErrorMessage = "Stars field is required")]
        public List<int> stararray { get; set; }




    }
}
