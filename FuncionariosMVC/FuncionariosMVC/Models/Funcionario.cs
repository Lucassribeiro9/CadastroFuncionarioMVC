using System.ComponentModel;
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
        [DisplayName("CPF")]
        // Regex CPF [RegularExpression(@"/^\d{3}.\d{3}.\d{3}-\d{2}$")]
        [ValidadorCpf(ErrorMessage = "Digite um CPF válido")]
        public string Cpf { get; set; }
        [DisplayName("RG")]
        [Required(ErrorMessage = "RG obrigatório")]
        [ValidadorRg(ErrorMessage = "Digite um RG válido")]
        public string Rg { get; set; }
        [DisplayName("Orgão Emissor")]
        public string OrgaoEmissor { get; set; }
        [DisplayName("Título Eleitoral")]
        public string TituloEleitoral { get; set; }
        [DisplayName("CEP")]
        public string Cep { get; set; }
        [DisplayName("Endereço")]
        public string Logradouro { get; set; }
        [DisplayName("Número")]
        public string NumeroEndereco { get; set; }
        [DisplayName("Complemento")]
        public string Complemento { get; set; }
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
        [DisplayName("Estado")]
        public string Estado { get; set; }
        [DisplayName("Ativo")]
        public bool FuncionarioAtivo { get; set; }
        [DisplayName("Possui cargo como gestor?")]
        public bool CargoGestor { get; set; }

        [DisplayName("Departamento")]
        public Departamentos Departamentos { get; set; }

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
