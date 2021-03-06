using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESERVA_RESTAURANT_PNT1.Data;
using RESERVA_RESTAURANT_PNT1.Models;

namespace RESERVA_RESTAURANT_PNT1.Controllers
{
    public class BebidasController : Controller
    {
        private readonly RestaurantContext _context;

        public BebidasController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Bebidas
        public async Task<IActionResult> Index()
        {
              return _context.Bebidas != null ? 
                          View(await _context.Bebidas.ToListAsync()) :
                          Problem("Entity set 'RestaurantContext.Bebidas'  is null.");
        }

        // GET: Bebidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bebidas == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // GET: Bebidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bebidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cm3,Nombre,Marca,Precio,TipoBebida,Presentacion")] Bebida bebida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bebida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bebida);
        }

        // GET: Bebidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bebidas == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null)
            {
                return NotFound();
            }
            return View(bebida);
        }

        // POST: Bebidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cm3,Nombre,Marca,Precio,TipoBebida,Presentacion")] Bebida bebida)
        {
            if (id != bebida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bebida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BebidaExists(bebida.Id))
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
            return View(bebida);
        }

        // GET: Bebidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bebidas == null)
            {
                return NotFound();
            }

            var bebida = await _context.Bebidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bebida == null)
            {
                return NotFound();
            }

            return View(bebida);
        }

        // POST: Bebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bebidas == null)
            {
                return Problem("Entity set 'RestaurantContext.Bebidas'  is null.");
            }
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida != null)
            {
                _context.Bebidas.Remove(bebida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BebidaExists(int id)
        {
          return (_context.Bebidas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
