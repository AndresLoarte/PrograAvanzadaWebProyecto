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
    public class TipoEquipoesController : Controller
    {
        private readonly TaycoContext _context;

        public TipoEquipoesController(TaycoContext context)
        {
            _context = context;
        }

        // GET: TipoEquipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEquipo.ToListAsync());
        }

        // GET: TipoEquipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo
                .FirstOrDefaultAsync(m => m.TipoEquipoId == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEquipoId,NombreTipo")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo.FindAsync(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEquipoId,NombreTipo")] TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.TipoEquipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEquipoExists(tipoEquipo.TipoEquipoId))
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
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipo
                .FirstOrDefaultAsync(m => m.TipoEquipoId == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEquipo = await _context.TipoEquipo.FindAsync(id);
            _context.TipoEquipo.Remove(tipoEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEquipoExists(int id)
        {
            return _context.TipoEquipo.Any(e => e.TipoEquipoId == id);
        }
    }
}
