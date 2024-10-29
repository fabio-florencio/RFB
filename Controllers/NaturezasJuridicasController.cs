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
    public class NaturezasJuridicasController : Controller
    {
        private readonly RFBContext _context;

        public NaturezasJuridicasController(RFBContext context)
        {
            _context = context;
        }

        // GET: NaturezasJuridicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.NaturezasJuridicas.ToListAsync());
        }

        // GET: NaturezasJuridicas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturezaJuridica = await _context.NaturezasJuridicas
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (naturezaJuridica == null)
            {
                return NotFound();
            }

            return View(naturezaJuridica);
        }

        // GET: NaturezasJuridicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturezasJuridicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao")] NaturezaJuridica naturezaJuridica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(naturezaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naturezaJuridica);
        }

        // GET: NaturezasJuridicas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturezaJuridica = await _context.NaturezasJuridicas.FindAsync(id);
            if (naturezaJuridica == null)
            {
                return NotFound();
            }
            return View(naturezaJuridica);
        }

        // POST: NaturezasJuridicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Descricao")] NaturezaJuridica naturezaJuridica)
        {
            if (id != naturezaJuridica.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturezaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturezaJuridicaExists(naturezaJuridica.Codigo))
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
            return View(naturezaJuridica);
        }

        // GET: NaturezasJuridicas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturezaJuridica = await _context.NaturezasJuridicas
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (naturezaJuridica == null)
            {
                return NotFound();
            }

            return View(naturezaJuridica);
        }

        // POST: NaturezasJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var naturezaJuridica = await _context.NaturezasJuridicas.FindAsync(id);
            if (naturezaJuridica != null)
            {
                _context.NaturezasJuridicas.Remove(naturezaJuridica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaturezaJuridicaExists(string id)
        {
            return _context.NaturezasJuridicas.Any(e => e.Codigo == id);
        }
    }
}
