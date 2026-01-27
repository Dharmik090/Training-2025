using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    [RoutePrefix("api/v1/products")]
    public class ProductsV1Controller : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new { Version = "v1", Name = "Product A" });
        }
    }
}
