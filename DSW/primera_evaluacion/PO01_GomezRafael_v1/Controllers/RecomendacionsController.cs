using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PO01_GomezRafael_v1.Data;
using PO01_GomezRafael_v1.Models;

namespace PO01_GomezRafael_v1.Controllers
{
    public class RecomendacionsController : Controller
    {
        private readonly jardineriaContext _context;

        public RecomendacionsController(jardineriaContext context)
        {
            _context = context;
        }

        // GET: Recomendacions
        public async Task<IActionResult> Index()
        {
              return _context.Recomendacion != null ? 
                          View(await _context.Recomendacion.ToListAsync()) :
                          Problem("Entity set 'jardineriaContext.Recomendacion'  is null.");
        }
    }
}
