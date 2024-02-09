using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio2RafaGomez.Data;
using Ejercicio2RafaGomez.Models;

namespace Ejercicio2RafaGomez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GamesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            if (_context.Game == null)
            {
                return NotFound("Los juegos no han sido encontrados.");
            }

            List<Game> games = await _context.Game.Select(g => new Game
            {
                Id = g.Id,
                Title = g.Title,
                GenreId = g.GenreId,
                Genre = new Genre
                {
                    Id = g.Genre.Id,
                    Name = g.Genre.Name
                }
            }).ToListAsync();

            return games;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            if (_context.Game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            var game = await _context.Game
            .Where(g => g.Id == id)
            .Select(g => new Game
            {
                Id = g.Id,
                Title = g.Title,
                GenreId = g.GenreId,
                Genre = new Genre
                {
                    Id = g.Genre.Id,
                    Name = g.Genre.Name
                }
            })
            .FirstOrDefaultAsync();

            if (game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutGame (int id, GameDTO gameDTO)
        {
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            var genreIDs = await _context.Genre.Select(g => g.Id).ToArrayAsync();

            if (!genreIDs.Contains(gameDTO.GenreId))
            {
                return BadRequest($"El Id de género proporcionado ({gameDTO.GenreId}) no es válido.");
            }

            game.Id = id;
            game.Title = gameDTO.Title;
            game.GenreId = gameDTO.GenreId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!GameExists(id))
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            return Ok(game);
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Game>> PostGame(GameDTO gameDTO)
        {
            if (_context.Game == null)
            {
                return Problem("Entity set 'MyDbContext.Game'  is null.");
            }

            var genreIDs = await _context.Genre.Select(g => g.Id).ToArrayAsync();

            if (!genreIDs.Contains(gameDTO.GenreId))
            {
                return BadRequest($"El Id de género proporcionado ({gameDTO.GenreId}) no es válido.");
            }

            var game = new Game
            {
                Title = gameDTO.Title,
                GenreId = gameDTO.GenreId,
                Genre = null
            };

            _context.Game.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (_context.Game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            var game = await _context.Game.FindAsync(id);
            
            if (game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return Ok($"El juego con id: {id} ha sido eliminado.");
        }

        private bool GameExists(int id)
        {
            return (_context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
