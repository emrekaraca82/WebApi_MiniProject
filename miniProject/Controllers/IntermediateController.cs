using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntermediateController : ControllerBase
    {
        private readonly Context _context;

        public IntermediateController(Context context)
        {
            _context = context;
        }

        [HttpGet("getCompanyList")]
        public JsonResult GetCompanyList(int id)    
        {          
            var query = from ci in _context.Set<Intermediate>()
                        join c in _context.Set<Company>()                       
                        on ci.CompanyId equals c.ID 
                        join i in _context.Set<Information>()
                        on ci.InformationId equals i.ID into grouping
                        from i in grouping.DefaultIfEmpty()
                        where ci.CompanyId == id
                        select new { c.Name,i.FirstName };

            return new JsonResult(query);

        }

        [HttpGet("getInformationList")]
        public JsonResult GetInformationList(int id)
        {
            var query = from ci in _context.Set<Intermediate>()
                        join i in _context.Set<Information>()
                        on ci.InformationId equals i.ID
                        join c in _context.Set<Company>()
                        on ci.CompanyId equals c.ID into grouping
                        from c in grouping.DefaultIfEmpty()
                        where i.ID == id
                        select new { c.Name, i.FirstName };

            return new JsonResult(query);
        }
    }
}
