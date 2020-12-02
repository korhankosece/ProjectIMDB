using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<WatchList> WatchLists { get; set; }


    }
}
