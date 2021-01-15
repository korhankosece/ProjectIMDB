using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class VideoVM
    {
        [Required(ErrorMessage = "The Movie ID field is required")]

        [DisplayName("Movie ID")]
        public int movieid { get; set; }

        public string name { get; set; }

        [Required(ErrorMessage = "The Video Path field is required")]

        [DisplayName("Video Path")]

        public string videopath { get; set; }
        public List<Movie> movies { get; set; }

    }
}
