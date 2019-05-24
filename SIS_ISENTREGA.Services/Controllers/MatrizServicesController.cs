using SIS_ISENTREGA.Application;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIS_ISENTREGA.Services.Controllers
{
   [Authorize]
    //[RoutePrefix("api/")]
    public class MatrizServicesController : ApiController
    {
        private readonly IMatrizApplication _repositorio;
        public MatrizServicesController(IMatrizApplication repositorio)
        {
            _repositorio = repositorio;
        }
        [HttpPost]
        public HttpResponseMessage Create( MatrizViewModel newRegister)
        {
            try
            {
                _repositorio.Add(newRegister);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }
           
        }

        [HttpPut]
        public HttpResponseMessage Update(MatrizViewModel newRegister)
        {

            try
            {
                _repositorio.Update(newRegister);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                _repositorio.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }

        }

        [HttpGet]
        public HttpResponseMessage FindAll()
        {

            try
            {
               var lstRetorno= _repositorio.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, lstRetorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }

        }
    }
}
