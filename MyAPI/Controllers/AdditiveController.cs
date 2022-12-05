using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public class AdditiveController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public AdditiveController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Additive
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Additive>>> GetAdditive()
        {
            //return await _context.Additive.ToListAsync();
            
            var additive = await _context.Additive.ToListAsync();

            // Status Code and Status Description
            Result<IEnumerable<Additive>> result = new Result<IEnumerable<Additive>>
            {
                StatusCode = 200,
                StatusDescription = "Additives in database",
                ResultData = additive
            };

            return Ok(result);

        }

        // GET: api/Additive/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Additive>> GetAdditive(int id)
        {
            var additive = await _context.Additive.FindAsync(id);
            
            
            if (additive == null)
            {
                Result<Additive> whatever = new Result<Additive>
                {
                    StatusCode = 404,
                    StatusDescription = $"The additive with id {id} does not exist",
                    ResultData = null
                };
                return NotFound(whatever);
                //return NotFound($"Status Code: 404. The additive with id {id} was not found");
            }


            //return additive;


            // Status Code and Status Description

            Result<Additive> result = new Result<Additive>
            {
                StatusCode = 200,
                StatusDescription = $"The additive with id {id} was found",
                ResultData = additive
            };

            return Ok(result);


        }

        // PUT: api/Additive/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditive(int id, Additive additive)
        {
            if (id != additive.Id)
            {
                Result<Additive> result = new Result<Additive>
                {
                    StatusCode = 400,
                    StatusDescription = $"The additive with id {id} does not exist or does not match with additive in database",
                };
                return BadRequest(result);
            }

            _context.Entry(additive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditiveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Result<Additive> result_ = new Result<Additive>
            {
                StatusCode = 200,
                StatusDescription = "Record updated successfully",
                ResultData = additive
                
            };
            return Ok(result_);
            //return Ok("Record successfully created");
        }

        // POST: api/Additive
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Additive>> PostAdditive(Additive additive)
        {
            var updated_additive = _context.Additive.Add(additive);
            await _context.SaveChangesAsync();
            // var updated_additive = CreatedAtAction("GetAdditive", new { id = additive.Id }, additive);

            //return CreatedAtAction("GetAdditive", new { id = additive.Id }, additive);

            //Result<Additive> result = new Result<Additive>
            //{
            //StatusCode = 200,
            //StatusDescription = "Bad Request",
            //ResultData = updated_additive
            //};


            Result<Additive> result = new Result<Additive>
            {
                StatusCode = 201,
                StatusDescription = "Record created successfully",
                ResultData = updated_additive.Entity
             };

            
            //return CreatedAtAction("GetAdditive", new { id = result.ResultData.Id }, result);
           var additive_ = CreatedAtAction("GetAdditive", new { id = result.ResultData.Id }, result);
           return additive_;

        }

        // DELETE: api/Additive/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditive(int id)
        {
            var additive = await _context.Additive.FindAsync(id);
            if (additive == null)
            {
                Result<Additive> whatever = new Result<Additive>
                {
                    StatusCode = 404,
                    StatusDescription = $"The additive with id {id} does not exist",
                    ResultData = null
                };
                return NotFound(whatever);
            }

            _context.Additive.Remove(additive);
            await _context.SaveChangesAsync();

            Result<Additive> result = new Result<Additive>
            {
                StatusCode = 200,
                StatusDescription = $"The additive with id {id} was deleted",
                ResultData = null
            };
            return Ok(result);
        }

        private bool AdditiveExists(int id)
        {
            return _context.Additive.Any(e => e.Id == id);
        }
    }
}
