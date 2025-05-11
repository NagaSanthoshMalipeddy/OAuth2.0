using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OAuth2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn([FromForm]string credential)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential);
            return Ok(payload);
        }

        [HttpPost]
        [Route("loginWithFacebook")]
        public IActionResult LoginWithFaceBook([FromBody] string token)
        {
            return Ok(token);
        }
    }
}
