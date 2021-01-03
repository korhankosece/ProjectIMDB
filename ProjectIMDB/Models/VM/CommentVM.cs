using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class CommentVM
    {
        public int id { get; set; }
        public string username { get; set; }
        public string content { get; set; }
        public string header { get; set; }
        public string moviename { get; set; }

        public int movieid { get; set; }
        public int userid { get; set; }


        public DateTime adddate { get; set; }
        public DateTime updatedate { get; set; }
    }
}
