using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Empleado/GetById/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST api/empleado
        [HttpPost]
        [Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT api/empleado/5
        [HttpPut]
        [Route("api/Empleado/Update/{IdEmpleado}")]
        public IHttpActionResult Update(int IdEmpleado, [FromBody]ML.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;
            ML.Result results = BL.Empleado.Update(empleado);
            if (results.Correct)
            {
                return Content(HttpStatusCode.OK, results);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, results);
            }
        }

        // DELETE api/empleado/5
        [HttpGet]
        [Route("api/Empleado/Delete/{IdEmpleado}")]
        // GET: api/SubCategoria/Delete
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else //Error
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

    }
}
