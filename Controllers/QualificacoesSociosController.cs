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
    public class QualificacoesSociosController : Controller
    {
        private readonly RFBContext _context;

        public QualificacoesSociosController(RFBContext context)
        {
            _context = context;
        }

        // GET: QualificacoesSocios
        public async Task<IActionResult> Index()
        {
            return View(await _context.QualificacoesSocios.ToListAsync());
        }

        // GET: QualificacoesSocios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificacaoSocio = await _context.QualificacoesSocios
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (qualificacaoSocio == null)
            {
                return NotFound();
            }

            return View(qualificacaoSocio);
        }

        // GET: QualificacoesSocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QualificacoesSocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao")] QualificacaoSocio qualificacaoSocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualificacaoSocio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qualificacaoSocio);
        }

        // GET: QualificacoesSocios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificacaoSocio = await _context.QualificacoesSocios.FindAsync(id);
            if (qualificacaoSocio == null)
            {
                return NotFound();
            }
            return View(qualificacaoSocio);
        }

        // POST: QualificacoesSocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,Descricao")] QualificacaoSocio qualificacaoSocio)
        {
            if (id != qualificacaoSocio.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualificacaoSocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificacaoSocioExists(qualificacaoSocio.Codigo))
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
            return View(qualificacaoSocio);
        }

        // GET: QualificacoesSocios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificacaoSocio = await _context.QualificacoesSocios
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (qualificacaoSocio == null)
            {
                return NotFound();
            }

            return View(qualificacaoSocio);
        }

        // POST: QualificacoesSocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var qualificacaoSocio = await _context.QualificacoesSocios.FindAsync(id);
            if (qualificacaoSocio != null)
            {
                _context.QualificacoesSocios.Remove(qualificacaoSocio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificacaoSocioExists(string id)
        {
            return _context.QualificacoesSocios.Any(e => e.Codigo == id);
        }
    }
}
