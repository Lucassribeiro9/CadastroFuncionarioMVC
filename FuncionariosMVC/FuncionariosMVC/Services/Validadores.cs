using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace FuncionariosMVC.Services
{
    public class ValidadorRg : ValidationAttribute
    {
        public override bool IsValid(object? rg)
        {


            if (rg == null || string.IsNullOrEmpty(rg.ToString()))
            {
                return true;
            }
            else
            {
                return RGValidation.Validate(rg.ToString());
            }
        }
    }
    public class ValidadorCpf : ValidationAttribute
    {
        public override bool IsValid(object? cpf)
        {


            if (cpf == null || string.IsNullOrEmpty(cpf.ToString()))
            {
                return true;
            }
            else
            {
                return CpfValidation.Validate(cpf.ToString());
            }
        }
    }

}
