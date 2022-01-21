using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.API
{
    public class Bearer
    {
        public string Issuer { get; set; }
        public string Auidence { get; set; }
        public string SecurityKey { get; set; }
    
    }
}
