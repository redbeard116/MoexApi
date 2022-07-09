using Microsoft.AspNetCore.Mvc;

namespace MoexApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It`s work!";
        }
    }
}
