using BeYou.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeYou.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context contexto)
        {
            _context = contexto;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult acolhimento()
        {
            return View();
        }

        public IActionResult cadastrarCurso()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastrarCurso(cadastroCursos cursos)
        {
            _context.CadastroCursos.Add(cursos);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult cadastrarVaga()
        {
            return View();
        }

        [HttpPost]
        public IActionResult cadastrarVaga(cadastroVagasEmprego vagasEmprego)
        {
            _context.CadastroVagasEmprego.Add(vagasEmprego);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult capacitacaoECursos()
        {
            var cursos = _context.CadastroCursos.ToList();
            return View(cursos);
        }

        public IActionResult dadosImportantes()
        {
            return View();
        }

        public IActionResult doeParaUmaOng()
        {
            return View();
        }

        public IActionResult encontreUmaCasa()
        {
            return View();
        }

        public IActionResult indiqueUmaCasa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult indiqueUmaCasa(casasAcolhimento casas)
        {
            _context.casasAcolhimentos.Add(casas);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult informacoesLegais()
        {
            return View();
        }

        public IActionResult missaoVisaoValores()
        {
            return View();
        }

        public IActionResult mudeUmNome()
        {
            return View();
        }

        public IActionResult ondeProcurarVagas()
        {
            return View();
        }

        public IActionResult sejaUmParceiro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult sejaUmParceiro(cadastroParceiros parceiros)
        {
            _context.CadastroParceiros.Add(parceiros);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult sejaUmVoluntario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult sejaUmVoluntario(cadastroVoluntarios voluntarios)
        {
            _context.CadastroVoluntarios.Add(voluntarios);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult vagasDeEmprego()
        {
            var vagasEmprego = _context.CadastroVagasEmprego.ToList();
            return View(vagasEmprego);
        }

        public IActionResult verCandidatosParceiros()
        {
            var parceiros = _context.CadastroParceiros.ToList();
            return View(parceiros);
        }

        public IActionResult verCandidatosVoluntarios()
        {
            var voluntarios = _context.CadastroVoluntarios.ToList();
            return View(voluntarios);
        }

        public IActionResult verCasasIndicadas()
        {
            var casasIndicadas = _context.casasAcolhimentos.ToList();
            return View(casasIndicadas);
        }

        public IActionResult verCursosIndicados()
        {
            var cursos = _context.CadastroCursos.ToList();
            return View(cursos);
        }

        public IActionResult verVagasDeEmprego()
        {
            var vagasEmprego = _context.CadastroVagasEmprego.ToList();
            return View(vagasEmprego);
        }
    }
}