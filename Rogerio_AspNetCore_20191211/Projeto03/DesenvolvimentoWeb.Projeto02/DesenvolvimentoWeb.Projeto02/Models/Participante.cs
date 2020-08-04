using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Display(Name = "Evento:")]
        [Required(ErrorMessage = "O id do evento é obrigatório")]
        public int IdEvento { get; set; }

        [Display(Name = "Nome:")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "CPF:")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        [Display(Name = "Dt Nasc:")]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "A Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public Evento EventoInfo { get; set; }
    }
}
