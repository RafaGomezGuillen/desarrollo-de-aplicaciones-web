using GomezRafael_Musica.Data;
using GomezRafael_Musica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GomezRafael_Musica.Controllers
{
    public class AlbumsController:Controller
    {
        private readonly ChinookContext _context;

        public AlbumsController (ChinookContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index ()
        {
            var chinookContext = _context.Albums.Include(a => a.Artist);
            return View(await chinookContext.ToListAsync());
        }

        // GET: Albums
        // Lista de álbumes dependiendo del artista pasado como parámetro
        public async Task<IActionResult> AlbumsByArtist (Artist artist)
        {
            var chinookContext = _context.Albums.Include(a => a.Artist).Where(t => t.ArtistId == artist.ArtistId);
            return View(await chinookContext.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            var tracks = _context.Tracks.Include(t => t.Album).Where(t => t.AlbumId == id).ToList();

            album.Tracks = tracks;

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create ()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("AlbumId,Title,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                // Consulta para obtener los IDs de los álbumes
                var albumId = from c in _context.Albums
                              orderby c.AlbumId descending
                              select c.AlbumId;

                album.AlbumId = albumId.FirstOrDefault() + 1;

                // Recupera el artista desde la base de datos incluyendo la relación
                Artist? artist = await _context.Artists.FirstOrDefaultAsync(a => a.ArtistId == album.ArtistId);
                album.Artist = artist;

                _context.Add(album);
                ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", album.ArtistId);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult CreateAlbumByArtist (int id, string name)
        {
            // Id del artista
            ViewData["ArtistId"] = id;

            // Nombre del artista
            ViewData["name"] = name;
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAlbumByArtist ([Bind("AlbumId,Title,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                // Consulta para obtener los IDs de los álbumes
                var albumId = from c in _context.Albums
                              orderby c.AlbumId descending
                              select c.AlbumId;

                album.AlbumId = albumId.FirstOrDefault() + 1;

                // Recupera el artista desde la base de datos incluyendo la relación
                Artist? artist = await _context.Artists.FirstOrDefaultAsync(a => a.ArtistId == album.ArtistId);
                album.Artist = artist;

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name");
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("AlbumId,Title,ArtistId")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(album);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(album.AlbumId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistId", album.ArtistId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ChinookContext.Albums'  is null.");
            }

            var album = await _context.Albums.Include(a => a.Tracks).FirstOrDefaultAsync(m => m.AlbumId == id);

            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists (int id)
        {
            return (_context.Albums?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
