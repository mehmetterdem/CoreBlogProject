using JWT_Layer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultsController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Page1()
        {
            return Ok("Sayfa Bir için girişiniz başarılı");
        }
    }
}
