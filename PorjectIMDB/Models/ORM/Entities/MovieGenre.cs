using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class MovieGenre :Base
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
