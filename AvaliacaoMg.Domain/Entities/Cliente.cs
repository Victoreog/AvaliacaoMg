using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Socios = new HashSet<Socio>();
            Contatos = new HashSet<Contato>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public virtual ICollection<Socio> Socios { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}
