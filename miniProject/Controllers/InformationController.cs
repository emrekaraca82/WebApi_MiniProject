using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniProject.Models;

namespace miniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
       
        private readonly Context _context;
        public InformationController(Context context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetInformation()
        {
            var value = await _context.informations.ToListAsync();
            return Ok(value);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<Information>> GetInformation(int id)
        {
            var information = await _context.informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }
            return information;
        }

      
        [HttpPost("add")]
        public async Task<ActionResult<Information>> PostInformation(Information information)
        {
            _context.informations.Add(information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformation", new { id = information.ID }, information);
        }


        [HttpPut("update")]
        public async Task<IActionResult> PutInformation(int id, Information information)
        {
            if (id != information.ID)
            {
                return BadRequest();
            }

            _context.Entry(information).State = EntityState.Modified;

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
        public async Task<IActionResult> DeleteInformation(int id)
        {
            var information = await _context.informations.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            _context.informations.Remove(information);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
