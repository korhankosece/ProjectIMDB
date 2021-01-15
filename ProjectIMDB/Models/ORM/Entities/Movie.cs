using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class Movie: Base
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterURL { get; set; }
        public string Description { get; set; }
        public double TotalRate { get; set; }
        public double AvrPoint { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<MovieImages> MovieImages { get; set; }
        public List<MovieVideos> MovieVideos { get; set; }

        public List<WatchList> WatchLists { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<MoviePerson> MoviePeople { get; set; }




    }
}
