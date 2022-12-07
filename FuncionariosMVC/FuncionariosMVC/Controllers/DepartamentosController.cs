using FuncionariosMVC.Data;
using FuncionariosMVC.Models;
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
            return View(await _context.Departamentos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Nome")] Departamentos departamentos)
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
            if (id == null || _context.Departamentos == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Departamento não existe" });
            }
            return View(departamento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Departamentos departamentos)
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
            if (id == null || _context.Departamentos == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);
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
            if (_context.Departamentos == null)
            {
                return Problem("Entity set 'FuncionariosMVCContext.Departamentos'  is null.");
            }
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                _context.Departamentos.Remove(departamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }
        private bool DepartamentoExists(string nome)
        {
            return _context.Departamentos.Any(e => e.Nome == nome);
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
