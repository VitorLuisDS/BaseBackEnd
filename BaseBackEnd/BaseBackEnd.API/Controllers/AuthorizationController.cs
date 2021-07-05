using BaseBackEnd.API.Constants.Endpoints;
using BaseBackEnd.API.Constants.Messages;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Interfaces.Service.Security;
using BaseBackEnd.Domain.ViewModel.SecutityVms.PageVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using IAuthorizationService = BaseBackEnd.Domain.Interfaces.Service.Security.IAuthorizationService;

namespace BaseBackEnd.API.Controllers
{
    [Route(AuthorizationEndpoints.BASE_ENDPOINT)]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBaseBackEnd
    {
        private readonly IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService, IAuthenticationService authenticationService) : base(authenticationService)
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
