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
    public class cadastroCursosController : Controller
    {
        private readonly Context _context;

        public cadastroCursosController(Context context)
        {
            _context = context;
        }

        // GET: cadastroCursos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroCursos.ToListAsync());
        }

        // GET: cadastroCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCursos = await _context.CadastroCursos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroCursos == null)
            {
                return NotFound();
            }

            return View(cadastroCursos);
        }

        // GET: cadastroCursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadastroCursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_instituicao,curso,cidade_UF,duracao,turno")] cadastroCursos cadastroCursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroCursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(cadastroCursos);
        }

        // GET: cadastroCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCursos = await _context.CadastroCursos.FindAsync(id);
            if (cadastroCursos == null)
            {
                return NotFound();
            }
            return View(cadastroCursos);
        }

        // POST: cadastroCursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_instituicao,curso,cidade_UF,duracao,turno")] cadastroCursos cadastroCursos)
        {
            if (id != cadastroCursos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroCursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadastroCursosExists(cadastroCursos.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("verCursosIndicados", "Home");
            }
            return View(cadastroCursos);
        }

        // GET: cadastroCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCursos = await _context.CadastroCursos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroCursos == null)
            {
                return NotFound();
            }

            return View(cadastroCursos);
        }

        // POST: cadastroCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroCursos = await _context.CadastroCursos.FindAsync(id);
            _context.CadastroCursos.Remove(cadastroCursos);
            await _context.SaveChangesAsync();
            return RedirectToAction("verCursosIndicados", "Home");
        }

        private bool cadastroCursosExists(int id)
        {
            return _context.CadastroCursos.Any(e => e.ID == id);
        }
    }
}
