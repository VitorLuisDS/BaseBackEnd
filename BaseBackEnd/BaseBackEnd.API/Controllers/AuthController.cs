using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(ResponseBase<AccessTokenOutputVm>))]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthInputVm userAuthInputVm)
        {
            var user = await _authService.AuthenticateAsync(userAuthInputVm);
            if (user != default)
            {
                SetAccessTokenOnCookies(user);
                var response = new ResponseBase<AccessTokenOutputVm>(user, message: "User authenticated");
                return Ok(response);
            }
            else
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, "User does not exist"));
        }

        private void SetAccessTokenOnCookies(TokensOutputVm user)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            };

            HttpContext.Response.Cookies.Append("auth", user.RefreshToken, cookieOptions);
        }
    }
}
