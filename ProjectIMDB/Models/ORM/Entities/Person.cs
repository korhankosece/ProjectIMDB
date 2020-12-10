using ProjectIMDB.Models.Types;
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
        public DateTime? BirthDate { get; set; }
        public string Country { get; set; }
        public int JobID { get; set; }

        public List<MoviePerson> MoviePeople { get; set; }
        public List<PersonJob> PersonJobs { get; set; }

    }
}
