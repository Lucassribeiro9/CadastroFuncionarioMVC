using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuncionariosMVC.Data;
using FuncionariosMVC.Models;
using System.Diagnostics;

namespace FuncionariosMVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionariosMVCContext _context;

        public FuncionariosController(FuncionariosMVCContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário não existe" });
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,OrgaoEmissor,TituloEleitoral,Cep,Logradouro,NumeroEndereco,Complemento,Bairro,Cidade,Estado,FuncionarioAtivo,CargoGestor")] Funcionario funcionario)
        {
            if (FuncionarioExists(funcionario.Nome))
            {
                return RedirectToAction(nameof(Error), new { message = "Já existe um funcionário com este nome!" });
            }
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário inexistente" });
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,OrgaoEmissor,TituloEleitoral,Cep,Logradouro,NumeroEndereco,Complemento,Bairro,Cidade,Estado,FuncionarioAtivo,CargoGestor")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }

            if (FuncionarioExists(funcionario.Nome))
            {
                return RedirectToAction(nameof(Error), new { message = "Já existe um funcionário com este nome" });

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (ApplicationException e)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return RedirectToAction(nameof (Error), new { message = "Id não existe" });
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário não existe" });
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionario == null)
            {
                return Problem("Entity set 'FuncionariosMVCContext.Funcionario'  is null.");
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionario.Remove(funcionario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
        private bool FuncionarioExists(string nome)
        {
            return _context.Funcionario.Any(e => e.Nome == nome);
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
