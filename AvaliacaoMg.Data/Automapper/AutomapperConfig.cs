using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoMg.Data.Automapper
{
    public class AutomapperConfig
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperConfigProfile>();
            });
            return config;
        }
    }
}


