using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FuncionariosMVC.Services
{
    public class ValidadorCpf : ValidationAttribute
    {
        public ValidadorCpf()
        {
        }
        /*  public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

        } */


        public static string RemoveNaoNumericos(string text)
        {
            Regex reg = new Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }
        //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
        // cpf = RemoveNaoNumericos(cpf);

        public static bool ValidarCPF(string cpf)
        {

            string valor = cpf.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
            {

                return false;
            }

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                {

                    igual = false;
                }
            }

            if (igual || valor == "12345678909")
            {
                return false;
            }

            int[] numeros = new int[11];



            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {

                if (numeros[9] != 0)
                {

                    return false;
                }


            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;

            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {

                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {

                    return false;
                }
            }
            else if (numeros[10] != 11 - resultado)
            {

                return false;
            }
            return true;

        }
    }
}
