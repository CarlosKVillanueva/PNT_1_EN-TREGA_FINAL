using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RESERVA_RESTAURANT_PNT1.Data;
using RESERVA_RESTAURANT_PNT1.Models;

namespace RESERVA_RESTAURANT_PNT1.Controllers
{
    public class ReservasClienteController : Controller
    {
        private readonly RestaurantContext _context;
        private int CapacidadResto { get; set; } = Restaurant.Capacidad;


        public ReservasClienteController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: ReservasCliente
        public async Task<IActionResult> Index()
        {
            #region Prueba

            List<Reserva> reservas = _context.Reservas.ToList();
            ViewBag.capacidadLibre = CapacidadResto - reservas.Sum(r => r.Comensales);

            #endregion

            return View(await _context.Reservas.ToListAsync());
        }

        // GET: ReservasCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: ReservasCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservasCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Telefono,Mail,Comensales,Fecha,Hora,FormaPago,Newsletter")] Reserva reserva)
        {
            List<Reserva> reservas = _context.Reservas.ToList();
            bool haylugar = CapacidadResto > reservas.Sum(r => r.Comensales);

            if (ModelState.IsValid)
                if (haylugar)
                {
                    _context.Add(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            return View(reserva);
        }

        // GET: ReservasCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: ReservasCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Telefono,Mail,Comensales,Fecha,Hora,FormaPago,Newsletter")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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

            return View(reserva);
        }

        // GET: ReservasCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: ReservasCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'RestaurantContext.Reservas'  is null.");
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}