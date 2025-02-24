using System.ComponentModel.DataAnnotations;

namespace desafio.api.Core
{
    public class CpfCnpjValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpfCnpj = value as string;

            if (string.IsNullOrEmpty(cpfCnpj) || !CPFCNPJValidator.IsValidCpfCnpj(cpfCnpj))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}