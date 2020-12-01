﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class MovieStar:Base
    {
        public int MovieID { get; set; }
        public int PersonID { get; set; }


        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }
    }
}
