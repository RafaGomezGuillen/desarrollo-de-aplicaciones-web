using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIMusica_GomezRafael.Data;
using APIMusica_GomezRafael.Models;

namespace APIMusica_GomezRafael.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public AlbumsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            if (_context.Albums == null)
            {
                return NotFound("Los álbumes no han sido encontrados.");
            }

            List<Album> albums = await _context.Albums.Select(a => new Album
            {
                AlbumId = a.AlbumId,
                Title = a.Title,
                ArtistId = a.ArtistId,
                Artist = new Artist
                {
                    ArtistId = a.Artist.ArtistId,
                    Name = a.Artist.Name
                },
                Tracks = _context.Tracks.Where(track => track.AlbumId == a.AlbumId).ToList()
            }).OrderByDescending(a => a.Title).Take(10).ToListAsync();

            return albums;
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            if (_context.Albums == null)
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }

            var album = await _context.Albums.Where(a => a.AlbumId == id).Select(a => new Album
            {
                AlbumId = a.AlbumId,
                Title = a.Title,
                ArtistId = a.ArtistId,
                Artist = new Artist
                {
                    ArtistId = a.Artist.ArtistId,
                    Name = a.Artist.Name
                },
                Tracks = _context.Tracks.Where(track => track.AlbumId == a.AlbumId).ToList()
            }).FirstOrDefaultAsync();

            if (album == null)
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAlbum(int id, AlbumDTO albumDTO)
        {
            var album = await _context.Albums.FindAsync(id);

            if (album == null)
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }

            var artistIDs = await _context.Artists.Select(a => a.ArtistId).ToArrayAsync();

            if (!artistIDs.Contains(albumDTO.ArtistId))
            {
                return BadRequest($"El Id de artista proporcionado ({albumDTO.ArtistId}) no es válido.");
            }

            album.Title = albumDTO.Title;
            album.ArtistId = albumDTO.ArtistId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AlbumExists(id))
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }

            return Ok(album);
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Album>> PostAlbum(AlbumDTO albumDTO)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ChinookContext.Albums'  is null.");
            }

            var artistIDs = await _context.Artists.Select(a => a.ArtistId).ToArrayAsync();

            if (!artistIDs.Contains(albumDTO.ArtistId))
            {
                return BadRequest($"El Id de artista proporcionado ({albumDTO.ArtistId}) no es válido.");
            }

            // Consulta para obtener los IDs de los álbumes
            var albumId = from c in _context.Albums
                          orderby c.AlbumId descending
                          select c.AlbumId;

            var album = new Album
            {
                AlbumId = albumId.FirstOrDefault() + 1,
                Title = albumDTO.Title,
                ArtistId = albumDTO.ArtistId,
                Artist = null
            };

            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            if (_context.Albums == null)
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }

            var album = await _context.Albums.Include(a => a.Tracks).FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound($"El álbum con id: {id} no ha sido encontrado.");
            }
            else
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return Ok($"El álbum con id: {id} ha sido eliminado y las canciones asociados a él.");
        }

        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
