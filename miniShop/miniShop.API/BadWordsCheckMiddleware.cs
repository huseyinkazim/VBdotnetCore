using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.API
{
    public class BadWordsCheckMiddleware
    {
        private RequestDelegate next;

        public BadWordsCheckMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method.ToUpper()=="POST")
            {
                var incomingData = await httpContext.Request.ReadFormAsync();
                foreach (var item in incomingData)
                {
                    if (item.Value.Contains("bad words"))
                    {

                    }
                }
            }
            else
            {
                await next.Invoke(httpContext);
            }
        }
    }
}
