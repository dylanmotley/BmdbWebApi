using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BmdbWebApi.Data;
using BmdbWebApi.Models;

namespace BmdbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviegenresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviegenresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Moviegenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moviegenre>>> GetMoviegenre()
        {
            return await _context.Moviegenre.ToListAsync();
        }

        // GET: api/Moviegenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moviegenre>> GetMoviegenre(int id)
        {
            var moviegenre = await _context.Moviegenre.FindAsync(id);

            if (moviegenre == null)
            {
                return NotFound();
            }

            return moviegenre;
        }

        // PUT: api/Moviegenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoviegenre(int id, Moviegenre moviegenre)
        {
            if (id != moviegenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(moviegenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviegenreExists(id))
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

        // POST: api/Moviegenres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Moviegenre>> PostMoviegenre(Moviegenre moviegenre)
        {
            _context.Moviegenre.Add(moviegenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviegenre", new { id = moviegenre.Id }, moviegenre);
        }

        // DELETE: api/Moviegenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Moviegenre>> DeleteMoviegenre(int id)
        {
            var moviegenre = await _context.Moviegenre.FindAsync(id);
            if (moviegenre == null)
            {
                return NotFound();
            }

            _context.Moviegenre.Remove(moviegenre);
            await _context.SaveChangesAsync();

            return moviegenre;
        }

        private bool MoviegenreExists(int id)
        {
            return _context.Moviegenre.Any(e => e.Id == id);
        }
    }
}
