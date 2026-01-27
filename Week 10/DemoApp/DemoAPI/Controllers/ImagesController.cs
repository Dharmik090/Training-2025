using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{

    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public IHttpActionResult UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
                return BadRequest("Expected multipart/form-data");

            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            Request.Content.ReadAsMultipartAsync(provider);

            foreach (HttpContent file in provider.Contents)
            {
                string filename = file.Headers.ContentDisposition.FileName.Trim('"');
                Task<byte[]> bytes = file.ReadAsByteArrayAsync();

                // TODO: save image (DB, disk, cloud, etc.)
            }

            return Ok("Image uploaded successfully");
        }
    }
}
