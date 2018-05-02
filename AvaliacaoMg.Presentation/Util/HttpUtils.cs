using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoMg.Presentation.Util
{
    public class HttpUtils
    {
        public static string MontarUrlBase(ViewContext vwctx)
        {
            var request = vwctx.HttpContext.Request;

            object[] scheme = new object[] { request.Scheme, request.Host };
            return string.Format("{0}://{1}/", scheme);
        }
    }
}
