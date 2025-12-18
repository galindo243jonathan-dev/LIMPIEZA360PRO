using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Limpieza360Pro.Api.Models;
using Limpieza360Pro.Api.Data;

namespace Limpieza360Pro.Api.Controllers
{
    [ApiController]
    [Route("api/shoppinglist")]
    [Authorize]
    public class ShoppingListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShoppingListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.ShoppingLists.Include(i => i.Property).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.ShoppingLists.Include(i => i.Property).FirstOrDefaultAsync(i => i.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShoppingList item)
        {
            _context.ShoppingLists.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ShoppingList item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ShoppingLists.FindAsync(id);
            if (item == null) return NotFound();
            _context.ShoppingLists.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
