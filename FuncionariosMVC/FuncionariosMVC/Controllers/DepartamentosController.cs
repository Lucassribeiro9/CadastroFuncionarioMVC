using FuncionariosMVC.Data;
using FuncionariosMVC.Models;
using FuncionariosMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FuncionariosMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly FuncionariosMVCContext _context;

        public DepartamentosController(FuncionariosMVCContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamento.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var departamento = await _context.Departamento.FirstOrDefaultAsync(d => d.Id == id);
            if (departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Departamento não existe" });
            }
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Departamento departamentos)
        {
            if (DepartamentoExists(departamentos.Nome))
            {
                return RedirectToAction(nameof(Error), new { message = "Já existe um departamento com este nome!" });
            }
            if (ModelState.IsValid)
            {
                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Departamento não existe" });
            }
            return View(departamento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Departamento departamentos)
        {
            if (id != departamentos.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }

            if (DepartamentoExists(departamentos.Nome))
            {
                return RedirectToAction(nameof(Error), new { message = "Já existe um departamento com este nome" });

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentos);
                    await _context.SaveChangesAsync();
                }
                catch (ApplicationException e)
                {
                    if (!DepartamentoExists(departamentos.Id))
                    {
                        return RedirectToAction(nameof(Error), new { message = e.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamentos);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var departamento = await _context.Departamento.FirstOrDefaultAsync(d => d.Id == id);
            if (departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário não existe" });
            }

            return View(departamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departamento == null)
            {
                return Problem("Entity set 'FuncionariosMVCContext.Departamentos'  is null.");
            }
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamento.Remove(departamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.Id == id);
        }
        private bool DepartamentoExists(string nome)
        {
            return _context.Departamento.Any(e => e.Nome == nome);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
