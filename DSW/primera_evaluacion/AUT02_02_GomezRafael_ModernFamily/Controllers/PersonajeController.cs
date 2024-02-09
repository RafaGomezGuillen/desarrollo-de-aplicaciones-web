using AUT02_02_GomezRafael_ModernFamily.Models;
using Microsoft.AspNetCore.Mvc;

namespace AUT02_02_GomezRafael_ModernFamily.Controllers
{
    public class PersonajeController:Controller
    {
        private static List<Personaje> personajes = new()
        {
             new Personaje { Id = 1, Family = "The patriarch", Name = "Jay", NChildren = 2 },
             new Personaje { Id = 2, Family = "The patriarch", Name = "Gloria", NChildren = 1 },
             new Personaje { Id = 3, Family = "The drama queen", Name = "Mitchell", NChildren = 1 },
             new Personaje { Id = 4, Family = "The former rebel", Name = "Claire", NChildren = 3 }
        };

        public IActionResult Index ()
        {
            return View(personajes);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                personaje.Id = personajes.Max(a => a.Id) + 1;
                personajes.Add(personaje);
                return RedirectToAction("Index");
            }

            return View(personaje);
        }
    }
}
