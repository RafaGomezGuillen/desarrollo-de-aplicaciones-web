using APIMusica_GomezRafael.Data;
using APIMusica_GomezRafael.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMusica_GomezRafael.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController:ControllerBase
    {
        private readonly ChinookContext _context;

        public ArtistsController (ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists ()
        {
            if (_context.Artists == null)
            {
                return NotFound("Los artistas no han sido encontrados.");
            }

            List<Artist> artists = await _context.Artists.Select(a => new Artist
            {
                ArtistId = a.ArtistId,
                Name = a.Name,
                Albums = _context.Albums.Where(album => album.ArtistId == a.ArtistId).ToList()
            }).OrderBy(a => a.Name).Take(10).ToListAsync();

            return artists;
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Artist>> GetArtist (int id)
        {
            if (_context.Artists == null)
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }

            var artist = await _context.Artists.Where(a => a.ArtistId == id).Select(a => new Artist
            {
                ArtistId = a.ArtistId,
                Name = a.Name,
                Albums = _context.Albums.Where(album => album.ArtistId == a.ArtistId).ToList()
            }).FirstOrDefaultAsync();

            if (artist == null)
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutArtist (int id, ArtistDTO artistDTO)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }

            artist.Name = artistDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArtistExists(id))
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }

            return Ok(artist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Artist>> PostArtist (ArtistDTO artistDTO)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'ChinookContext.Artists'  is null.");
            }

            // Consulta para obtener los IDs de los artistas
            var artistId = from c in _context.Artists
                           orderby c.ArtistId descending
                           select c.ArtistId;

            var artist = new Artist
            {
                ArtistId = artistId.FirstOrDefault() + 1,
                Name = artistDTO.Name,
            };

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArtist (int id)
        {
            if (_context.Artists == null)
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }

            var artist = await _context.Artists.Include(a => a.Albums).FirstOrDefaultAsync(a => a.ArtistId == id);
            var albums = await _context.Albums.Include(t => t.Tracks).Where(a => a.ArtistId == id).ToListAsync();

            if (artist == null)
            {
                return NotFound($"El artista con id: {id} no ha sido encontrado.");
            }
            else
            {
                albums.ForEach(album => _context.Albums.Remove(album));
                _context.Artists.Remove(artist);
            }

            await _context.SaveChangesAsync();
            return Ok($"El artista con id: {id} ha sido eliminado y los álbumes asociados a él.");
        }

        private bool ArtistExists (int id)
        {
            return (_context.Artists?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
