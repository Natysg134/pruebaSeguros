using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seguros.Models;

namespace Seguros.Controllers
{
    public class SegurosController : ApiController
    {
        private SegurosContext db = new SegurosContext();

        private static List<string> abc = new List<string> { "a", "b", "c" };
        
        [HttpGet]
        public IEnumerable<Seguro> GetLetters()
        {
            return db.Seguros.AsEnumerable();
        }
    }
}
