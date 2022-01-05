using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using miniProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace miniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public CompanyController(Context context, IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetCompany()
        {
            var value = await _context.companies.ToListAsync();
            return Ok(value);
        }


        [HttpPost("add")]        
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.ID }, company);
        }


        [HttpPut("update")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.ID)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();

        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    
    }
}
