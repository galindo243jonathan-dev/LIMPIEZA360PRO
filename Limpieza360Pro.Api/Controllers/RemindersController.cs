using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Limpieza360Pro.Api.Models;
using Limpieza360Pro.Api.Data;

namespace Limpieza360Pro.Api.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    [Authorize]
    public class RemindersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RemindersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reminders = await _context.Reminders.Include(r => r.User).ToListAsync();
            return Ok(reminders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reminder = await _context.Reminders.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
            if (reminder == null) return NotFound();
            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reminder reminder)
        {
            _context.Reminders.Add(reminder);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = reminder.Id }, reminder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Reminder reminder)
        {
            if (id != reminder.Id) return BadRequest();
            _context.Entry(reminder).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);
            if (reminder == null) return NotFound();
            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
