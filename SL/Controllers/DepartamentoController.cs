using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET: api/Departamento
        [HttpGet]
        [Route("api/Departamento/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Departamento.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
