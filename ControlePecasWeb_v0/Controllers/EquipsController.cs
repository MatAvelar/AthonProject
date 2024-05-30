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
    public class EquipsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EquipsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Equips
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Tb_Equip.Include(e => e.Peca).Include(e => e.Pneu);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Equips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Tb_Equip
                .Include(e => e.Peca)
                .Include(e => e.Pneu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equip == null)
            {
                return NotFound();
            }

            return View(equip);
        }

        // GET: Equips/Create
        public IActionResult Create()
        {
            ViewData["PecaId"] = new SelectList(_context.Tb_Peca, "Id", "Id");
            ViewData["PneuId"] = new SelectList(_context.Tb_Pneu, "Id", "Id");
            return View();
        }

        // POST: Equips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Desc,Horimetro,PneuId,PecaId")] Equip equip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PecaId"] = new SelectList(_context.Tb_Peca, "Id", "Id", equip.PecaId);
            ViewData["PneuId"] = new SelectList(_context.Tb_Pneu, "Id", "Id", equip.PneuId);
            return View(equip);
        }

        // GET: Equips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Tb_Equip.FindAsync(id);
            if (equip == null)
            {
                return NotFound();
            }
            ViewData["PecaId"] = new SelectList(_context.Tb_Peca, "Id", "Id", equip.PecaId);
            ViewData["PneuId"] = new SelectList(_context.Tb_Pneu, "Id", "Id", equip.PneuId);
            return View(equip);
        }

        // POST: Equips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Marca,Desc,Horimetro,PneuId,PecaId")] Equip equip)
        {
            if (id != equip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipExists(equip.Id))
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
            ViewData["PecaId"] = new SelectList(_context.Tb_Peca, "Id", "Id", equip.PecaId);
            ViewData["PneuId"] = new SelectList(_context.Tb_Pneu, "Id", "Id", equip.PneuId);
            return View(equip);
        }

        // GET: Equips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equip = await _context.Tb_Equip
                .Include(e => e.Peca)
                .Include(e => e.Pneu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equip == null)
            {
                return NotFound();
            }

            return View(equip);
        }

        // POST: Equips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equip = await _context.Tb_Equip.FindAsync(id);
            if (equip != null)
            {
                _context.Tb_Equip.Remove(equip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipExists(int id)
        {
            return _context.Tb_Equip.Any(e => e.Id == id);
        }
    }
}
