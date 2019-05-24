using SIS_ISENTREGA.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIS_ISENTREGA.Services.Controllers
{
    [Authorize]
    public class PontoServicesController : ApiController
    {
        private readonly IPontoApplication _repositorio;
        public PontoServicesController(IPontoApplication repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public HttpResponseMessage Create(PontoViewModel newRegister)
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
        public HttpResponseMessage Update(PontoViewModel newRegister)
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
    }
}
