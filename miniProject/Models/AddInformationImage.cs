using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Models
{
    public class AddInformationImage
    {
        //  public int ID { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public string BusinessPhone { get; set; }
        public string Address { get; set; }
        public IFormFile Image { get; set; }
       
       
    }
}
