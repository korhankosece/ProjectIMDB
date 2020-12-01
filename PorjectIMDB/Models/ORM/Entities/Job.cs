using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Entities
{
    public class Job : Base
    {
        public string Name { get; set; }

        public List<PersonJob> PersonJobs { get; set; }

    }
}
