using FuncionariosMVC.Data;
using FuncionariosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosMVC.Services
{
    public class DepartamentoService
    {
        private readonly FuncionariosMVCContext _context;

        public DepartamentoService(FuncionariosMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
