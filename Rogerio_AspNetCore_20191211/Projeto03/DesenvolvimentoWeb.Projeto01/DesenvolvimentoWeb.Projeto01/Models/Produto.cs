using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto01.Models
{
    public class Produto
    {
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}
