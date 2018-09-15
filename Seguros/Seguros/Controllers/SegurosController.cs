using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        [HttpPost]
        public HttpResponseMessage Post(Seguro Seguro)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);              
            }

            if (Seguro.TipoRiesgo == "alto" && Seguro.Cobertura > 50)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Tipo de Riesgo Alto, cobertura debe ser menor a 50");
            }

            db.Seguros.Add(Seguro);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
            HttpResponseMessage respuesta = Request.CreateResponse(HttpStatusCode.Created, Seguro);
            return respuesta;
        }

        [HttpPut]
        public HttpResponseMessage Put(Seguro Seguro)
        {
            var resultado = db.Seguros.SingleOrDefault(s => s.Id == Seguro.Id);
            if (resultado != null)
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (Seguro.TipoRiesgo == "alto" && Seguro.Cobertura > 50)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Tipo de Riesgo Alto, cobertura debe ser menor a 50");
                }

                resultado = Seguro;
                db.Entry(resultado).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Seguro Seguro = db.Seguros.Find(id);

            if (Seguro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Seguros.Remove(Seguro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Seguro);

        }



        

        

    }
}
