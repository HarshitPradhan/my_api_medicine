using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public CategoryController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _context.categories.ToListAsync());
        }



        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            _context.categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok();
        }



        // PUT: api/Category
        [HttpPut]
        public async Task<IActionResult> Put(Category category)
        {

            if (ModelState.IsValid)
            {
                _context.categories.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            return BadRequest();
        }


        // DELETE: api/Category/x (x = id)
        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var category = await _context.categories.FindAsync(CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
