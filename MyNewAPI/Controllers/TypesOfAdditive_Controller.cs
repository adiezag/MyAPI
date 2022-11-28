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
    public class TypesOfAdditive_Controller : ControllerBase
    {
        private readonly MyNewAPIDBContext _context;

        public TypesOfAdditive_Controller(MyNewAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/TypesOfAdditive_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypesOfAdditive_>>> GetTypesOfAdditives()
        {
            return await _context.TypesOfAdditives.ToListAsync();
        }

        // GET: api/TypesOfAdditive_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypesOfAdditive_>> GetTypesOfAdditive_(int id)
        {
            var typesOfAdditive_ = await _context.TypesOfAdditives.FindAsync(id);

            if (typesOfAdditive_ == null)
            {
                return NotFound();
            }

            return typesOfAdditive_;
        }

        // PUT: api/TypesOfAdditive_/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypesOfAdditive_(int id, TypesOfAdditive_ typesOfAdditive_)
        {
            if (id != typesOfAdditive_.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(typesOfAdditive_).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypesOfAdditive_Exists(id))
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

        // POST: api/TypesOfAdditive_
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypesOfAdditive_>> PostTypesOfAdditive_(TypesOfAdditive_ typesOfAdditive_)
        {
            _context.TypesOfAdditives.Add(typesOfAdditive_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypesOfAdditive_", new { id = typesOfAdditive_.TypeId }, typesOfAdditive_);
        }

        // DELETE: api/TypesOfAdditive_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypesOfAdditive_(int id)
        {
            var typesOfAdditive_ = await _context.TypesOfAdditives.FindAsync(id);
            if (typesOfAdditive_ == null)
            {
                return NotFound();
            }

            _context.TypesOfAdditives.Remove(typesOfAdditive_);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypesOfAdditive_Exists(int id)
        {
            return _context.TypesOfAdditives.Any(e => e.TypeId == id);
        }
    }
}
