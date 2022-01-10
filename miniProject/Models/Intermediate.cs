using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Models
{
    public class Intermediate
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InformationId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Information Information { get; set; }
    }
}
