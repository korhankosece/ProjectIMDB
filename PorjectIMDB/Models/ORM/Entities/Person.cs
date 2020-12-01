using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class Person : Base
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }


        public List<MovieStar> MovieStars { get; set; }
        public List<MovieScenarist> MovieScenarists { get; set; }
        public List<MovieDirector> MovieDirectors { get; set; }
        public List<PersonJob> PersonJobs { get; set; }
    }
}
