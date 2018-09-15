using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Seguros.Controllers
{
    public class SegurosController : ApiController
    {
        private static List<string> abc = new List<string> { "a", "b", "c" };
        
        [HttpGet]
        public IEnumerable<string> GetLetters()
        {
            return abc;
        }
    }
}
