using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.Interfaces.UnityOfWork;
using BaseBackEnd.Domain.ViewModels.SecutityVms;
using BaseBackEnd.Domain.ViewModels.UserVms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseBackEnd.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IAuthService _authService;
        public AuthController(IUnityOfWork unityOfWork, IAuthService authService)
        {
            _unityOfWork = unityOfWork;
            _authService = authService;
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(AccessTokenOutputVm))]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthInputVm userAuthInputVm)
        {
            var user = await _authService.AuthenticateAsync(userAuthInputVm);
            try
            {


                await _unityOfWork.CommitAsync();
            }catch(Exception a)
            {
                return Ok(a);
            }
            return Ok(user);
        }
    }
}
