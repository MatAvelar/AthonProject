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
    public class PecasController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PecasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Pecas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tb_Peca.ToListAsync());
        }

        // GET: Pecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Tb_Peca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // GET: Pecas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartNumber,Seg,Desc,Medida")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peca);
        }

        // GET: Pecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Tb_Peca.FindAsync(id);
            if (peca == null)
            {
                return NotFound();
            }
            return View(peca);
        }

        // POST: Pecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartNumber,Seg,Desc,Medida")] Peca peca)
        {
            if (id != peca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecaExists(peca.Id))
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
            return View(peca);
        }

        // GET: Pecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peca = await _context.Tb_Peca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // POST: Pecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peca = await _context.Tb_Peca.FindAsync(id);
            if (peca != null)
            {
                _context.Tb_Peca.Remove(peca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecaExists(int id)
        {
            return _context.Tb_Peca.Any(e => e.Id == id);
        }
    }
}
