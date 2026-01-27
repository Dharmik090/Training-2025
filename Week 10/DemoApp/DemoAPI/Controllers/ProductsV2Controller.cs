using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    [RoutePrefix("api/v2/products")]
    public class ProductsV2Controller : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new { Version = "v2", Name = "Product A", Price = 100 });
        }
    }
}
