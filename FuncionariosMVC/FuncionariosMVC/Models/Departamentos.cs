using System.ComponentModel.DataAnnotations;

namespace FuncionariosMVC.Models
{
    public class Departamentos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public Departamentos()
        {
        }

        public Departamentos(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
