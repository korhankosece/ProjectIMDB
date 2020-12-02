using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class WatchList : Base
    {
        public int MovieID { get; set; }
        public int UserID { get; set; }



        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
