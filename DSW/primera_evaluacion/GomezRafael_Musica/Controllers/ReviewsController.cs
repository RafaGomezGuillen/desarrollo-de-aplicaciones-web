using GomezRafael_Musica.Data;
using GomezRafael_Musica.Models;
using Microsoft.AspNetCore.Mvc;

namespace GomezRafael_Musica.Controllers
{
    public class ReviewsController:Controller
    {
        private readonly ChinookContext _context;

        public ReviewsController (ChinookContext context)
        {
            _context = context;
        }

        // GET: Reviews/Create
        public IActionResult Create (int artistId, string name)
        {
            // Id del artista
            ViewData["ArtistId"] = artistId;

            // Nombre del artista
            ViewData["name"] = name;
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("Id,Title,Description,Value,ArtistId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();

                // Redirijo a los detalles del artista para ver el comentario subido
                return RedirectToAction("Details", "Artists", new { id = review.ArtistId });
            }
            return View(review);
        }

        private bool ReviewExists (int id)
        {
            return (_context.Review?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
