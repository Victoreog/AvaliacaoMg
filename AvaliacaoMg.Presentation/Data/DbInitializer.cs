using AvaliacaoMg.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Presentation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AvaliacaoMgContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
