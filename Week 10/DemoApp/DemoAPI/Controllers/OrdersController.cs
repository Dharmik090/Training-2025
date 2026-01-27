using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    [Authorize]
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult Get([FromUri] string version)
        {
            //string versionHeader = Request.Headers
            //                     .GetValues("X-Api-Version")
            //                     .FirstOrDefault();

            if (version == "1")
            {
                return Ok(new { Version = "v1", Orders = 10 });
            }

            if (version == "2")
            {
                return Ok(new { Version = "v2", Orders = 10, Total = 500 });
            }

            return BadRequest("Invalid API version");
        }
    }

}
