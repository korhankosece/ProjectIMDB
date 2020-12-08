using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class RateVM
    {
        public int id { get; set; }
        public string username { get; set; }
        public double point { get; set; }
        public string moviename { get; set; }
        public DateTime adddate { get; set; }
        public DateTime updatedate { get; set; }
    }
}
