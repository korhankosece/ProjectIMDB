using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class SearchVM
    {
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value?.ToLower();
            }
        }

        //public string name { get; set; }

        public List<int> genrename { get; set; }
        

    }
}
