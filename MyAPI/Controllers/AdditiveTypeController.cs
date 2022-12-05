using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveTypeController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public AdditiveTypeController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/AdditiveType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditiveType>>> GetAdditiveType()
        {
            return await _context.AdditiveType.ToListAsync();
        }

        // GET: api/AdditiveType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditiveType>> GetAdditiveType(int id)
        {
            var additiveType = await _context.AdditiveType.FindAsync(id);

            if (additiveType == null)
            {
                return NotFound();
            }

            return additiveType;
        }

        // PUT: api/AdditiveType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditiveType(int id, AdditiveType additiveType)
        {
            if (id != additiveType.Id)
            {
                return BadRequest();
            }

            _context.Entry(additiveType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditiveTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdditiveType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdditiveType>> PostAdditiveType(AdditiveType additiveType)
        {
            _context.AdditiveType.Add(additiveType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditiveType", new { id = additiveType.Id }, additiveType);
        }

        // DELETE: api/AdditiveType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditiveType(int id)
        {
            var additiveType = await _context.AdditiveType.FindAsync(id);
            if (additiveType == null)
            {
                return NotFound();
            }

            _context.AdditiveType.Remove(additiveType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditiveTypeExists(int id)
        {
            return _context.AdditiveType.Any(e => e.Id == id);
        }
    }
}
