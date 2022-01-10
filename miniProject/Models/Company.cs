using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Intermediate> Intermediates { get; set; }
    }
}
