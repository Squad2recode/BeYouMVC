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
    public class cadastroVoluntariosController : Controller
    {
        private readonly Context _context;

        public cadastroVoluntariosController(Context context)
        {
            _context = context;
        }

        // GET: cadastroVoluntarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroVoluntarios.ToListAsync());
        }

        // GET: cadastroVoluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntarios = await _context.CadastroVoluntarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroVoluntarios == null)
            {
                return NotFound();
            }

            return View(cadastroVoluntarios);
        }

        // GET: cadastroVoluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadastroVoluntarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nome_voluntario,idade,email,telefone,mensagem_voluntario")] cadastroVoluntarios cadastroVoluntarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroVoluntarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(cadastroVoluntarios);
        }

        // GET: cadastroVoluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntarios = await _context.CadastroVoluntarios.FindAsync(id);
            if (cadastroVoluntarios == null)
            {
                return NotFound();
            }
            return View(cadastroVoluntarios);
        }

        // POST: cadastroVoluntarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nome_voluntario,idade,email,telefone,mensagem_voluntario")] cadastroVoluntarios cadastroVoluntarios)
        {
            if (id != cadastroVoluntarios.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroVoluntarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadastroVoluntariosExists(cadastroVoluntarios.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("verCandidatosVoluntarios", "Home");
            }
            return View(cadastroVoluntarios);
        }

        // GET: cadastroVoluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntarios = await _context.CadastroVoluntarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroVoluntarios == null)
            {
                return NotFound();
            }

            return View(cadastroVoluntarios);
        }

        // POST: cadastroVoluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroVoluntarios = await _context.CadastroVoluntarios.FindAsync(id);
            _context.CadastroVoluntarios.Remove(cadastroVoluntarios);
            await _context.SaveChangesAsync();
            return RedirectToAction("verCandidatosVoluntarios", "Home");
        }

        private bool cadastroVoluntariosExists(int id)
        {
            return _context.CadastroVoluntarios.Any(e => e.ID == id);
        }
    }
}
