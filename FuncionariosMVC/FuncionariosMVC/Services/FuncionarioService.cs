using FuncionariosMVC.Data;
using FuncionariosMVC.Models;
using FuncionariosMVC.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosMVC.Services
{
    public class FuncionarioService
    {
        private readonly FuncionariosMVCContext _context;

        public FuncionarioService(FuncionariosMVCContext context) { _context = context; }

        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionario.ToListAsync();
        }
        public async Task InsertAsync(Funcionario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Funcionario> FindByIDAsync(int id)
        {
            return await _context.Funcionario.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Funcionario.FindAsync(id);
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
                
            }
        }

        public async Task UpdateAsync(Funcionario obj)
        {
            bool hasAny = await _context.Funcionario.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
