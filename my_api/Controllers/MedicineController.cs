using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace my_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly AuthenticationContext _context;


        public MedicineController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Medicine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()
        {
            return Ok(await _context.medicines.ToListAsync());
        }

        // GET: api/Medicine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetStudentDetails(int id)
        {
            var medicine = await _context.medicines.FindAsync(id);

            if (medicine == null)
            {
                return BadRequest();
            }

            return Ok(medicine);
        }



        // POST: api/Medicine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicine>> AddMedicine(Medicine medicine )
        {
            _context.medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return Ok();
        }



        // PUT: api/Medicine
        [HttpPut]
        public async Task<IActionResult> Put(Medicine medicine)
        {

            if (ModelState.IsValid)
            {
                _context.medicines.Update(medicine);
                await _context.SaveChangesAsync();
                return Ok(medicine);
            }
            return BadRequest();
        }


        // DELETE: api/Medicine/x (x = id)
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMedicine(int Id)
        {
            var medicine = await _context.medicines.FindAsync(Id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
