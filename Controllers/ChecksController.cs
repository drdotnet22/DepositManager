using DepositManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ChecksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Checks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Check>>> GetCheck()
        {
            if (_context.Check == null)
            {
                return NotFound();
            }
            return await _context.Check.ToListAsync();
        }

        // GET: api/Checks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Check>> GetCheck(Guid id)
        {
            if (_context.Check == null)
            {
                return NotFound();
            }
            var check = await _context.Check.FindAsync(id);

            if (check == null)
            {
                return NotFound();
            }

            return check;
        }

        // PUT: api/Checks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheck(Guid id, Check check)
        {
            if (id != check.CheckId)
            {
                return BadRequest();
            }

            _context.Entry(check).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckExists(id))
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

        // POST: api/Checks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Check>> PostCheck(Check check)
        {
            if (_context.Check == null)
            {
                return Problem("Entity set 'MyDbContext.Check'  is null.");
            }
            _context.Check.Add(check);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCheck), new { id = check.CheckId }, check);
        }

        // DELETE: api/Checks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheck(Guid id)
        {
            if (_context.Check == null)
            {
                return NotFound();
            }
            var check = await _context.Check.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            _context.Check.Remove(check);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckExists(Guid id)
        {
            return (_context.Check?.Any(e => e.CheckId == id)).GetValueOrDefault();
        }
    }
}
