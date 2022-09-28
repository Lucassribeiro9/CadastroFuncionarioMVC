using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FuncionariosMVC.Models;

namespace FuncionariosMVC.Data
{
    public class FuncionariosMVCContext : DbContext
    {
        public FuncionariosMVCContext (DbContextOptions<FuncionariosMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; } = default!;
    }
}
