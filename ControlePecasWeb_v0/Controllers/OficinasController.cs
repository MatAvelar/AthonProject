using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePecasWeb_v0.Data;
using ControlePecasWeb_v0.Models;
using Microsoft.AspNetCore.Authorization;

namespace ControlePecasWeb_v0.Controllers
{
    [Authorize]
    public class OficinasController : Controller
    {
        private readonly ApplicationDBContext _context;

        public OficinasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Oficinas
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Tb_Oficina.Include(o => o.Equip).Include(o => o.User);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Oficinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Tb_Oficina
                .Include(o => o.Equip)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // GET: Oficinas/Create
        public IActionResult Create()
        {
            ViewData["EquipId"] = new SelectList(_context.Tb_Equip, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Tb_User, "Id", "Id");
            return View();
        }

        // POST: Oficinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,UserId,EquipId")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oficina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipId"] = new SelectList(_context.Tb_Equip, "Id", "Id", oficina.EquipId);
            ViewData["UserId"] = new SelectList(_context.Tb_User, "Id", "Id", oficina.UserId);
            return View(oficina);
        }

        // GET: Oficinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Tb_Oficina.FindAsync(id);
            if (oficina == null)
            {
                return NotFound();
            }
            ViewData["EquipId"] = new SelectList(_context.Tb_Equip, "Id", "Id", oficina.EquipId);
            ViewData["UserId"] = new SelectList(_context.Tb_User, "Id", "Id", oficina.UserId);
            return View(oficina);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,UserId,EquipId")] Oficina oficina)
        {
            if (id != oficina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oficina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OficinaExists(oficina.Id))
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
            ViewData["EquipId"] = new SelectList(_context.Tb_Equip, "Id", "Id", oficina.EquipId);
            ViewData["UserId"] = new SelectList(_context.Tb_User, "Id", "Id", oficina.UserId);
            return View(oficina);
        }

        // GET: Oficinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Tb_Oficina
                .Include(o => o.Equip)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oficina = await _context.Tb_Oficina.FindAsync(id);
            if (oficina != null)
            {
                _context.Tb_Oficina.Remove(oficina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OficinaExists(int id)
        {
            return _context.Tb_Oficina.Any(e => e.Id == id);
        }
    }
}
