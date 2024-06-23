using biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly ApplicationDBContext _db;

        public EmprestimoController(ApplicationDBContext dBContext)
        {
            _db = dBContext;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimoModels> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModels emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModels emprestimos = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimos == null)
            {
                return NotFound();
            }

            return View(emprestimos);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModels emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModels emprestimos = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimos == null)
            {
                return NotFound();
            }

            return View(emprestimos);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModels emprestimos)
        {
            if (emprestimos == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimos);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
