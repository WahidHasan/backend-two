using Microsoft.AspNetCore.Mvc;

namespace Workshop_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok("This is public data with caching");
        }

        [HttpGet("private")]
        public IActionResult GetPrivateData()
        {
            return Ok("This is private data with caching");
        }

        [HttpGet("no-cache")]
        public IActionResult GetNoCacheData()
        {
            return Ok("This is no-cache caching");
        }
    }
}
