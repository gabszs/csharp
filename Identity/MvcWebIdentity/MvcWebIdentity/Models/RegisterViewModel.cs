// using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MvcWebIdentity.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        [EmailAddress]
        public string? Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas nao sao iguais")]
        public string? ConfirmPassword { get; set; }

    }
}
