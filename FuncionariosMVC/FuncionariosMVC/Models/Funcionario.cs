using System.ComponentModel.DataAnnotations;
using FuncionariosMVC.Services;

namespace FuncionariosMVC.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve ter no mínimo três caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF obrigatório")]
        [CustomValidation.ValidadorCpf]
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgaoEmissor { get; set; }
        public string TituloEleitoral { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool FuncionarioAtivo { get; set; }
        public bool CargoGestor { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, string cpf, string rg, string orgaoEmissor, string tituloEleitoral, string cep, string logradouro, string numeroEndereco, string complemento, string bairro, string cidade, string estado, bool funcionarioAtivo, bool cargoGestor)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            OrgaoEmissor = orgaoEmissor;
            TituloEleitoral = tituloEleitoral;
            Cep = cep;
            Logradouro = logradouro;
            NumeroEndereco = numeroEndereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            FuncionarioAtivo = funcionarioAtivo;
            CargoGestor = cargoGestor;
        }
    }
}
