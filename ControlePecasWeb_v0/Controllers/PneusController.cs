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
    public class PneusController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PneusController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Pneus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tb_Pneu.ToListAsync());
        }

        // GET: Pneus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pneu = await _context.Tb_Pneu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pneu == null)
            {
                return NotFound();
            }

            return View(pneu);
        }

        // GET: Pneus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pneus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Seg,Desc,Medida")] Pneu pneu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pneu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pneu);
        }

        // GET: Pneus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pneu = await _context.Tb_Pneu.FindAsync(id);
            if (pneu == null)
            {
                return NotFound();
            }
            return View(pneu);
        }

        // POST: Pneus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Seg,Desc,Medida")] Pneu pneu)
        {
            if (id != pneu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pneu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PneuExists(pneu.Id))
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
            return View(pneu);
        }

        // GET: Pneus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pneu = await _context.Tb_Pneu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pneu == null)
            {
                return NotFound();
            }

            return View(pneu);
        }

        // POST: Pneus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pneu = await _context.Tb_Pneu.FindAsync(id);
            if (pneu != null)
            {
                _context.Tb_Pneu.Remove(pneu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PneuExists(int id)
        {
            return _context.Tb_Pneu.Any(e => e.Id == id);
        }
    }
}
