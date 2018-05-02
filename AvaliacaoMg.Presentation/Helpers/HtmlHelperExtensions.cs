using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Presentation.Helpers
{
    public static class HtmlHelperExtensions
    {
       
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                            select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }
        
    }
}
