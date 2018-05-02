using AutoMapper;
using AvaliacaoMg.Data.ViewModels;
using AvaliacaoMg.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.Automapper
{
    public class AutomapperConfigProfile:Profile
    {
        public AutomapperConfigProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Socio, SocioViewModel>().ReverseMap();
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
