using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjectIMDB.Models.VM
{
    public class UserPageVM
    {
        public IPagedList<WatchList> UserWatch { get; set; }
        public IPagedList<Rate> UserRate { get; set; }
        public User User { get; set; }

    }
}
