using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Domain.Entities
{
    public enum Tipo
    {
        Fixo, Residencial, Celular
    }

    public class Contato
    {
        public int IdContato { get; set; }
        public int IdCliente { get; set; }
        public Tipo Tipo { get; set; }
        public string DDD { get; set; }
        public int Numero { get; set; }
        public string Email { get; set; }
        public Cliente Cliente { get; set; }
    }
}
