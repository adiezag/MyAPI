using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewAPI.Models;

namespace MyNewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Additive_Controller : ControllerBase
    {
        private readonly MyNewAPIDBContext _context;

        public Additive_Controller(MyNewAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Additive_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Additive_>>> GetAdditives()
        {
            return await _context.Additives.ToListAsync();
        }

        // GET: api/Additive_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Additive_>> GetAdditive_(int id)
        {
            var additive_ = await _context.Additives.FindAsync(id);

            if (additive_ == null)
            {
                return NotFound();
            }

            return additive_;
        }

        // PUT: api/Additive_/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditive_(int id, Additive_ additive_)
        {
            if (id != additive_.AdditiveId)
            {
                return BadRequest();
            }

            _context.Entry(additive_).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Additive_Exists(id))
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

        // POST: api/Additive_
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Additive_>> PostAdditive_(Additive_ additive_)
        {
            _context.Additives.Add(additive_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditive_", new { id = additive_.AdditiveId }, additive_);
        }

        // DELETE: api/Additive_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditive_(int id)
        {
            var additive_ = await _context.Additives.FindAsync(id);
            if (additive_ == null)
            {
                return NotFound();
            }

            _context.Additives.Remove(additive_);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Additive_Exists(int id)
        {
            return _context.Additives.Any(e => e.AdditiveId == id);
        }
    }
}
