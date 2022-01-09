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
    public class cadastroParceirosController : Controller
    {
        private readonly Context _context;

        public cadastroParceirosController(Context context)
        {
            _context = context;
        }

        // GET: cadastroParceiros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroParceiros.ToListAsync());
        }

        // GET: cadastroParceiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiros = await _context.CadastroParceiros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroParceiros == null)
            {
                return NotFound();
            }

            return View(cadastroParceiros);
        }

        // GET: cadastroParceiros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadastroParceiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_parceiro,email,telefone,mensagem_parceiro")] cadastroParceiros cadastroParceiros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroParceiros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(cadastroParceiros);
        }

        // GET: cadastroParceiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiros = await _context.CadastroParceiros.FindAsync(id);
            if (cadastroParceiros == null)
            {
                return NotFound();
            }
            return View(cadastroParceiros);
        }

        // POST: cadastroParceiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_parceiro,email,telefone,mensagem_parceiro")] cadastroParceiros cadastroParceiros)
        {
            if (id != cadastroParceiros.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroParceiros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadastroParceirosExists(cadastroParceiros.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("verCandidatosParceiros", "Home");
            }
            return View(cadastroParceiros);
        }

        // GET: cadastroParceiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiros = await _context.CadastroParceiros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroParceiros == null)
            {
                return NotFound();
            }

            return View(cadastroParceiros);
        }

        // POST: cadastroParceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroParceiros = await _context.CadastroParceiros.FindAsync(id);
            _context.CadastroParceiros.Remove(cadastroParceiros);
            await _context.SaveChangesAsync();
            return RedirectToAction("verCandidatosParceiros", "Home");
        }

        private bool cadastroParceirosExists(int id)
        {
            return _context.CadastroParceiros.Any(e => e.ID == id);
        }
    }
}
