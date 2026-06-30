using CountryCrud.Data;
using CountryCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Country country)
        {
            if (id != country.Id)
                return BadRequest();

            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return NotFound();

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}