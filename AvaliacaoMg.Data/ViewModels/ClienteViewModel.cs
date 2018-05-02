using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Data.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Socios = new List<SocioViewModel>();
            Contatos = new List<ContatoViewModel>();
        }

        public int IdCliente { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cnpj { get; set; }

        
        public IList<SocioViewModel> Socios { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Endereco { get; set; }

        
        public IList<ContatoViewModel> Contatos { get; set; }
    }
}
