using System.ComponentModel.DataAnnotations;

namespace MvcWebIdentity.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required, MaxLength(80, ErrorMessage = "O nome nao deve conter mais que 80 caracteres")]
        public string? Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }



        public int age { get; set; }

        [MaxLength(80)]
        public string? Curso { get; set; }

    }
}
