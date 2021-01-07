using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.VM
{
    public class UserPageVM
    {
        public List<WatchList> UserWatch { get; set; }
    }
}
