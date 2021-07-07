using BaseBackEnd.Security.API.Constants.Endpoints;
using BaseBackEnd.Security.API.Constants.Messages;
using BaseBackEnd.Security.API.Models.Attributes;
using BaseBackEnd.Security.API.Models.Base;
using BaseBackEnd.Security.API.Services.Auth;
using BaseBackEnd.Security.API.ViewModels.PageVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BaseBackEnd.Security.API.Controllers
{
    [Route(AuthorizationEndpoints.BASE_ENDPOINT)]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBaseBackEnd
    {
        private readonly AuthorizationService _authorizationService;
        public AuthorizationController(AuthorizationService authorizationService, AuthenticationService authenticationService) : base(authenticationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet(AuthorizationEndpoints.ALLOWED_PAGE_FUNCTIONALITIES)]
        [ProducesBase(typeof(ResponseBase<PageAuthorizationOutputVm>))]
        [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AllowedPageFunctionalities(string moduleCode, string pageCode)
        {
            var userId = await UserId;
            var pageModuleAuthorizationInputVm = new PageAuthorizationInputVm
            {
                ModuleCode = moduleCode,
                PageCode = pageCode
            };

            var pageAuthorizationOutput = await _authorizationService.GetPageAuthorizationByUserAsync(userId, pageModuleAuthorizationInputVm);
            if (pageAuthorizationOutput != default)
            {
                var response = new ResponseBase<PageAuthorizationOutputVm>(pageAuthorizationOutput);
                return Ok(response);
            }
            else
            {
                var response = new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.UNAUTHORIZED_MSG);
                return Unauthorized(response);
            }
        }
    }
}
