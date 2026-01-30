namespace FuncionariosMVC.Models.ViewModels
{
    public class FuncFormViewModel
    {
        public Funcionario Funcionario { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
