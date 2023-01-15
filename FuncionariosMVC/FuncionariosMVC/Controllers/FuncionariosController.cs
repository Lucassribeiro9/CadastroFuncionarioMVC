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
using FuncionariosMVC.Services;
using FuncionariosMVC.Models.ViewModels;
using FuncionariosMVC.Services.Exceptions;

namespace FuncionariosMVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly DepartamentoService _departamentoService;
        private readonly FuncionarioService _funcionarioService;


        public FuncionariosController(DepartamentoService departamentoService, FuncionarioService funcionarioService)
        {
            _departamentoService = departamentoService;
            _funcionarioService = funcionarioService;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var list = await _funcionarioService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departmentos = await _departamentoService.FindAllAsync();
            var viewModel = new FuncFormViewModel { Departamentos = departmentos };
            return View(viewModel);
        }
        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var funcionario = await _funcionarioService.FindByIDAsync(id.Value);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário não existe" });
            }

            return View(funcionario);
        }



        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,OrgaoEmissor,TituloEleitoral,Cep,Logradouro,NumeroEndereco,Complemento,Bairro,Cidade,Estado,FuncionarioAtivo,CargoGestor,Departamentos")] Funcionario funcionario)
        {
            /*  if (FuncionarioExists(funcionario.Nome))
             {
                 return RedirectToAction(nameof(Error), new { message = "Já existe um funcionário com este nome!" });
             }*/
            if (ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new FuncFormViewModel { Funcionario = funcionario, Departamentos = departamentos };
                return View(viewModel);
            }
            await _funcionarioService.InsertAsync(funcionario);
            return RedirectToAction(nameof(Index));

        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var funcionario = await _funcionarioService.FindByIDAsync(id.Value);
            if (funcionario == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Funcionário inexistente" });
            }
            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            FuncFormViewModel viewModel = new FuncFormViewModel { Funcionario = funcionario, Departamentos = departamentos };
            return View(viewModel);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,OrgaoEmissor,TituloEleitoral,Cep,Logradouro,NumeroEndereco,Complemento,Bairro,Cidade,Estado,FuncionarioAtivo,CargoGestor,Departamentos")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }

           /* if (FuncionarioExists(funcionario.Nome))
            {
                return RedirectToAction(nameof(Error), new { message = "Já existe um funcionário com este nome" });

            } */

            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new FuncFormViewModel { Funcionario = funcionario, Departamentos = departamentos };
                return View(viewModel);
            }
            try
            {
                await _funcionarioService.UpdateAsync(funcionario);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var funcionario = await _funcionarioService.FindByIDAsync(id.Value);
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
            try
            {
                await _funcionarioService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        /* erro
        private bool FuncionarioExists(int id)
        {
            return _funcionarioService.Any(e => e.Id == id);
        }
        private bool FuncionarioExists(string nome)
        {
            return _context.Funcionario.Any(e => e.Nome == nome);
        }
         */
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
