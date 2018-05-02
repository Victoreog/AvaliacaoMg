using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Data.ViewModels
{
    public class SocioViewModel
    {
        public int IdSocio { get; set; }
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cpf { get; set; }
    }
}
