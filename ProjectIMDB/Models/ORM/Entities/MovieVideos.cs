using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class MovieVideos : Base
    {
        public string VideoPath { get; set; }
        public int MovieID { get; set; }


        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
