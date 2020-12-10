using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BelaRosa_MVC_AspNetCore.Models.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Nome é campo Obrigatorio.")]
        [MinLength(5,ErrorMessage="Nome de possuir mais de cinco caracter.")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Data de Nascimento é campo obrigatorio.")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage="Genero é campo obrigatorio.")]
        public string Genero { get; set; }

        [Required(ErrorMessage="CPF é campor obrigatorio.")]
        public string CPF { get; set; }

        [Required(ErrorMessage="Telefone é campo obrigatorio.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage="Email é campo obrigatorio.")]
        [EmailAddress(ErrorMessage="Email em formato invalido.")]
        public string Email { get; set; }

        [Required(ErrorMessage="Senha é campo obrigatotio.")]
        [MinLength(6,ErrorMessage="Minimo permitido seis caracter")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage="Confirmação de Senha é campo obrigatorio")]
        [NotMappedAttribute]
        [Compare("Senha", ErrorMessage="Senhas não são iguais")]
        public string ConfirmacaoSenha { get; set; }
        public string Tipo { get; set; }
    }
}