using GomezRafael_Musica.Data;
using GomezRafael_Musica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GomezRafael_Musica.Controllers
{
    public class ArtistsController:Controller
    {
        private readonly ChinookContext _context;

        public ArtistsController (ChinookContext context)
        {
            _context = context;
        }

        // GET: Artists
        public async Task<IActionResult> Index ()
        {
            return _context.Artists != null ?
                        View(await _context.Artists.ToListAsync()) :
                        Problem("Entity set 'ChinookContext.Artists'  is null.");
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);

            var reviews = _context.Review.Where(t => t.ArtistId == id).ToList();

            var viewModel = new ReviewArtist
            {
                artist = artist,
                reviewList = reviews
            };

            if (artist == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Artists/Create
        public IActionResult Create ()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("ArtistId,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                // Consulta para obtener los IDs de los artistas
                var artistId = from c in _context.Artists
                               orderby c.ArtistId descending
                               select c.ArtistId;

                artist.ArtistId = artistId.FirstOrDefault() + 1;

                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("ArtistId,Name")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || _context.Artists == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            if (_context.Artists == null)
            {
                return Problem("Entity set 'ChinookContext.Artists'  is null.");
            }
            var artist = await _context.Artists.Include(a => a.Albums).FirstOrDefaultAsync(a => a.ArtistId == id);
            var albums = await _context.Albums.Include(t => t.Tracks).Where(a => a.ArtistId == id).ToListAsync();

            albums.ForEach(album => _context.Albums.Remove(album));

            if (artist != null)
            {
                _context.Artists.Remove(artist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists (int id)
        {
            return (_context.Artists?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
