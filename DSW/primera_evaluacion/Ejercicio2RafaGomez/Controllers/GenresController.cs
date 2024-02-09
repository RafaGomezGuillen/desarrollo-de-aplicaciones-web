using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio2RafaGomez.Data;
using Ejercicio2RafaGomez.Models;

namespace Ejercicio2RafaGomez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GenresController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre()
        {
            if (_context.Genre == null)
            {
                return NotFound("Lo géneros no han sido encontrados.");
            }

            List<Genre> genres = await _context.Genre.Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Games =  _context.Game.Where(game => game.GenreId == genre.Id).ToList(),
            }).ToListAsync();

            return genres;
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if (_context.Genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            var genre = await _context.Genre
            .Where(g => g.Id == id)
            .Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Games = _context.Game.Where(game => game.GenreId == genre.Id).ToList(),
            })
            .FirstOrDefaultAsync();

            if (genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            return genre;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, GenreDTO genreDTO)
        {
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            genre.Id = id;
            genre.Name = genreDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!GenreExists(id))
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            return Ok(genre);
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(GenreDTO genreDTO)
        {
            if (_context.Genre == null)
            {
                return Problem("Entity set 'MyDbContext.Genre'  is null.");
            }

            var genre = new Genre
            {
                Name = genreDTO.Name,
            };

            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            if (_context.Genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }
            
            var genre = await _context.Genre.FindAsync(id);
            
            if (genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return Ok($"El género con id: {id} ha sido eliminado y los juegos asociados a él.");
        }

        private bool GenreExists(int id)
        {
            return (_context.Genre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
