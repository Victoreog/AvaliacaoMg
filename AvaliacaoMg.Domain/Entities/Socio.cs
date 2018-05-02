using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Domain.Entities
{
    public class Socio
    {
        public int IdSocio { get; set; }
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public virtual Cliente Cliente {get;set;}
    }
}
