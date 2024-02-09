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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay juegos en la base de datos
            if (_context.Game == null)
            {
                return NotFound("Los juegos no han sido encontrados.");
            }

            // Obtiene y devuelve la lista de juegos con sus géneros asociados
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay juegos en la base de datos
            if (_context.Game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            // Obtiene y devuelve el juego solicitado con sus géneros asociados
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
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutGame (int id, GameDTO gameDTO)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Busca y actualiza un juego en la base de datos
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound($"El juego con id: {id} no ha sido encontrado.");
            }

            // Se comprueba si el género introducido existe
            var genreIDs = await _context.Genre.Select(g => g.Id).ToArrayAsync();

            if (!genreIDs.Contains(gameDTO.GenreId))
            {
                return BadRequest($"El Id de género proporcionado ({gameDTO.GenreId}) no es válido.");
            }

            // Actualiza la información del juego y guarda los cambios
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Game>> PostGame(GameDTO gameDTO)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Se comprueba si el género introducido existe
            var genreIDs = await _context.Genre.Select(g => g.Id).ToArrayAsync();

            if (!genreIDs.Contains(gameDTO.GenreId))
            {
                return BadRequest($"El Id de género proporcionado ({gameDTO.GenreId}) no es válido.");
            }

            // Se crea el juego y guarda los cambios
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteGame(int id)
        {
            // Verifica si el usuario está autenticado
            var user = HttpContext.User;

            if (user == null || !User.Identity.IsAuthenticated)
            {
                return Unauthorized("Error: No estás autorizado para realizar esta acción.");
            }

            // Verifica si hay juegos en la base de datos
            if (_context.Game == null)
            {
                return NotFound($"No hay juegos en la base de datos.");
            }

            // Busca y elimina un juego de la base de datos
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
