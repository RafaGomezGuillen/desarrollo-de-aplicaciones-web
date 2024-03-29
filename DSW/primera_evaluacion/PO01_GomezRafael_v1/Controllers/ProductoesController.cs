﻿using System;
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
    public class ProductoesController : Controller
    {
        private readonly jardineriaContext _context;

        public ProductoesController(jardineriaContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var jardineriaContext = _context.Productos.Include(p => p.GamaNavigation);
            return View(await jardineriaContext.ToListAsync());
        }

        // GET: Productoes
        public async Task<IActionResult> ProductosPorGama (string id)
        {
            ViewData["gama"] = id;

            var jardineriaContext = _context.Productos.Include(p => p.GamaNavigation).Where(g => g.Gama == id);
            return View(await jardineriaContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.GamaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);

            var recomendaciones = _context.Recomendacion.Where(t => t.CodigoProducto == id).ToList();

            var viewModel = new ProductoRecomendacion
            {
                producto = producto,
                recomendaciones = recomendaciones
            };

            if (producto == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["Gama"] = new SelectList(_context.GamaProductos, "Gama", "Gama");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Gama"] = new SelectList(_context.GamaProductos, "Gama", "Gama", producto.Gama);
            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult CrearProductoPorGama (string id)
        {
            ViewData["Gama"] = id;
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProductoPorGama ([Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("ProductosPorGama", "Productoes", new { id = producto.Gama });
            }
            //ViewData["Gama"] = new SelectList(_context.GamaProductos, "Gama", "Gama", producto.Gama);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Gama"] = new SelectList(_context.GamaProductos, "Gama", "Gama", producto.Gama);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProducto,Nombre,Gama,Dimensiones,Proveedor,Descripcion,CantidadEnStock,PrecioVenta,PrecioProveedor")] Producto producto)
        {
            if (id != producto.CodigoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.CodigoProducto))
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
            ViewData["Gama"] = new SelectList(_context.GamaProductos, "Gama", "Gama", producto.Gama);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.GamaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'jardineriaContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.CodigoProducto == id)).GetValueOrDefault();
        }
    }
}
