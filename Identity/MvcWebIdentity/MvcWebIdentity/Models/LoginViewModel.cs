using System.ComponentModel.DataAnnotations;


namespace MvcWebIdentity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = " O email e obrigatorio")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha e obrigatoria")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "lembrar-me")]
        public bool RemenberMe { get; set; }




    }
}
