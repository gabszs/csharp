﻿using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        [EmailAddress(ErrorMessage = "Digite um E-mail valido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado nao e valido")]
        public string Celular { get; set; }
    }
}
