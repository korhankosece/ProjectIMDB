using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class MoviePageVM
    {

        public List<Movie> MovieList { get; set; }
        public Movie MovieDetail { get; set; }
       

        //public string Name { get; set; }
        //public string Poster { get; set; }
        //public double Rate { get; set; }
        //public int ReleaseDate { get; set; }
        //public string Description { get; set; }
    }
}
