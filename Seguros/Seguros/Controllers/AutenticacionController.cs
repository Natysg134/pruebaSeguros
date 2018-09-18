using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seguros.Models;

namespace Seguros.Controllers
{
    public class AutenticacionController : ApiController
    {
        //private UnitOfWork db = new UnitOfWork();
        private SegurosContext db = new SegurosContext();

        [HttpPost]
        public HttpResponseMessage VerificarUsuario(Usuario obj)
        {

            var usuario = db.Usuarios.Where(x => x.NombreUsuario.Equals(obj.NombreUsuario) && x.Clave.Equals(obj.Clave)).FirstOrDefault();
            HttpResponseMessage respuesta = Request.CreateResponse(HttpStatusCode.Created, usuario.NombreUsuario);
            return respuesta;

        }

    }
}
