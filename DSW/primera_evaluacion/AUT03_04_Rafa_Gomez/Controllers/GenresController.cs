using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AUT03_04_Rafa_Gomez.Data;
using AUT03_04_Rafa_Gomez.Models;
using Microsoft.AspNetCore.Authorization;

namespace AUT03_04_Rafa_Gomez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController:ControllerBase
    {
        private readonly MyDbContext _context;

        public GenresController (MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenre ()
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;
            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay géneros en la base de datos
            if (_context.Genre == null)
            {
                return NotFound("Lo géneros no han sido encontrados.");
            }

            // Obtiene y devuelve la lista de géneros con sus juegos asociados
            List<Genre> genres = await _context.Genre.Select(genre => new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                Games = _context.Game.Where(game => game.GenreId == genre.Id).ToList(),
            }).ToListAsync();

            return genres;
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Genre>> GetGenre (int id)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;
            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay géneros en la base de datos
            if (_context.Genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            // Obtiene y devuelve un género con sus juegos asociados
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre (int id, GenreDTO genreDTO)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;
            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Busca y actualiza un género en la base de datos
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            // Actualiza la información del género y guarda los cambios
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
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre (GenreDTO genreDTO)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;
            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Crea y guarda un nuevo género en la base de datos
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
        public async Task<IActionResult> DeleteGenre (int id)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;
            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay géneros en la base de datos
            if (_context.Genre == null)
            {
                return NotFound($"No hay géneros en la base de datos.");
            }

            // Busca y elimina un género de la base de datos
            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound($"El género con id: {id} no ha sido encontrado.");
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return Ok($"El género con id: {id} ha sido eliminado y los juegos asociados a él.");
        }

        private bool GenreExists (int id)
        {
            return (_context.Genre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}