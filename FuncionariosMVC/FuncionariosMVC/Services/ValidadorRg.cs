using DocumentValidator;
using System.ComponentModel.DataAnnotations;

namespace FuncionariosMVC.Services
{
    public class ValidadorRg : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {


            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }
            else
            {
                return RGValidation.Validate(value.ToString());
            }
        }
    }
}
