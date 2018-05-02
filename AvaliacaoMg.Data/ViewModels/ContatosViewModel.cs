using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Data.ViewModels
{
    public enum Tipo
    {
        Fixo, Residencial, Celular
    }

    public class ContatoViewModel
    {
        public int IdContato { get; set; }
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O campo {0} é inválido.")]
        public Tipo Tipo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string DDD { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }
    }
}
