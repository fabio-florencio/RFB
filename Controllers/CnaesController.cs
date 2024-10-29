using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RFB.Data;
using RFB.Models;

namespace RFB.Controllers
{
    public class CnaesController : Controller
    {
        private readonly RFBContext _context;

        public CnaesController(RFBContext context)
        {
            _context = context;
        }

        // GET: Cnaes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cnae.ToListAsync());
        }

        // GET: Cnaes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnae = await _context.Cnae
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (cnae == null)
            {
                return NotFound();
            }

            return View(cnae);
        }

        // GET: Cnaes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cnaes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao")] Cnae cnae)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cnae);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cnae);
        }

        // GET: Cnaes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnae = await _context.Cnae.FindAsync(id);
            if (cnae == null)
            {
                return NotFound();
            }
            return View(cnae);
        }

        // POST: Cnaes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Descricao")] Cnae cnae)
        {
            if (id != cnae.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cnae);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CnaeExists(cnae.Codigo))
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
            return View(cnae);
        }

        // GET: Cnaes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cnae = await _context.Cnae
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (cnae == null)
            {
                return NotFound();
            }

            return View(cnae);
        }

        // POST: Cnaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cnae = await _context.Cnae.FindAsync(id);
            if (cnae != null)
            {
                _context.Cnae.Remove(cnae);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CnaeExists(string id)
        {
            return _context.Cnae.Any(e => e.Codigo == id);
        }
    }
}
