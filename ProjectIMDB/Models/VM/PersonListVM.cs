using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class PersonListVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string nationality { get; set; }
        public DateTime adddate { get; set; }
        public DateTime? updatedate { get; set; }
        public bool isdeleted { get; set; }
    }
}
