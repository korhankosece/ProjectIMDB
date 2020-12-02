using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class Rate : Base
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public double Point { get; set; }



        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

    }
}
