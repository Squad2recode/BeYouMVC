#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeYou.Models;

namespace BeYou.Controllers
{
    public class casasAcolhimentoesController : Controller
    {
        private readonly Context _context;

        public casasAcolhimentoesController(Context context)
        {
            _context = context;
        }

        // GET: casasAcolhimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.casasAcolhimentos.ToListAsync());
        }

        // GET: casasAcolhimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasAcolhimento = await _context.casasAcolhimentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (casasAcolhimento == null)
            {
                return NotFound();
            }

            return View(casasAcolhimento);
        }

        // GET: casasAcolhimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: casasAcolhimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_casa,site,estado,cidade")] casasAcolhimento casasAcolhimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casasAcolhimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(casasAcolhimento);
        }

        // GET: casasAcolhimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasAcolhimento = await _context.casasAcolhimentos.FindAsync(id);
            if (casasAcolhimento == null)
            {
                return NotFound();
            }
            return View(casasAcolhimento);
        }

        // POST: casasAcolhimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_casa,site,estado,cidade")] casasAcolhimento casasAcolhimento)
        {
            if (id != casasAcolhimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casasAcolhimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!casasAcolhimentoExists(casasAcolhimento.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("verCasasIndicadas", "Home");
            }
            return View(casasAcolhimento);
        }

        // GET: casasAcolhimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casasAcolhimento = await _context.casasAcolhimentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (casasAcolhimento == null)
            {
                return NotFound();
            }

            return View(casasAcolhimento);
        }

        // POST: casasAcolhimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casasAcolhimento = await _context.casasAcolhimentos.FindAsync(id);
            _context.casasAcolhimentos.Remove(casasAcolhimento);
            await _context.SaveChangesAsync();
            return RedirectToAction("verCasasIndicadas", "Home");
        }

        private bool casasAcolhimentoExists(int id)
        {
            return _context.casasAcolhimentos.Any(e => e.ID == id);
        }
    }
}
