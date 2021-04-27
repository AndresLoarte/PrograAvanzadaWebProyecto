using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.W.Models;

namespace FrontEnd.W.Controllers
{
    public class ReservasController : Controller
    {
        private readonly TaycoContext _context;

        public ReservasController(TaycoContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var taycoContext = _context.Reserva.Include(r => r.Equipo).Include(r => r.TipoCancha).Include(r => r.User);
            return View(await taycoContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Equipo)
                .Include(r => r.TipoCancha)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "NombreEquipo");
            ViewData["TipoCanchaId"] = new SelectList(_context.TipoCancha, "TipoCanchaId", "Descripcion");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Correo");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaId,UserId,TipoCanchaId,EquipoId,FechaReserva,Hora,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "NombreEquipo", reserva.EquipoId);
            ViewData["TipoCanchaId"] = new SelectList(_context.TipoCancha, "TipoCanchaId", "Descripcion", reserva.TipoCanchaId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Correo", reserva.UserId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "NombreEquipo", reserva.EquipoId);
            ViewData["TipoCanchaId"] = new SelectList(_context.TipoCancha, "TipoCanchaId", "Descripcion", reserva.TipoCanchaId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Correo", reserva.UserId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaId,UserId,TipoCanchaId,EquipoId,FechaReserva,Hora,Estado")] Reserva reserva)
        {
            if (id != reserva.ReservaId)
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
                    if (!ReservaExists(reserva.ReservaId))
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
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "NombreEquipo", reserva.EquipoId);
            ViewData["TipoCanchaId"] = new SelectList(_context.TipoCancha, "TipoCanchaId", "Descripcion", reserva.TipoCanchaId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Correo", reserva.UserId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Equipo)
                .Include(r => r.TipoCancha)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReservaId == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ReservaId == id);
        }
    }
}
