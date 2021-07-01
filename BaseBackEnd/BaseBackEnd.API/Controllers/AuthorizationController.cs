using BaseBackEnd.API.Constants.Endpoints;
using BaseBackEnd.API.Models.Attributes;
using BaseBackEnd.API.Models.Base;
using BaseBackEnd.Domain.Constants.Messages;
using BaseBackEnd.Domain.ViewModels.SecutityVms.PageVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet(AuthorizationEndpoints.ALLOWED_PAGE_FUNCTIONALITIES)]
        [ProducesBase(typeof(ResponseBase<PageAuthorizationOutputVm>))]
        [ProducesResponseTypeBase(typeof(ResponseBase), HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> AllowedPageFunctionalities(string moduleCode, string pageCode)
        {
            var pageModuleAuthorizationInputVm = new PageAuthorizationInputVm
            {
                ModuleCode = moduleCode,
                PageCode = pageCode
            };

            var headerAccessToken = HttpContext.Request.Headers.First(i => i.Key.Equals("Authorization")).Value[0];
            var pageAuthorizationOutput = await _authorizationService.AuthorizeUserAsync(headerAccessToken, pageModuleAuthorizationInputVm);
            if (pageAuthorizationOutput != default && pageAuthorizationOutput.AllowedFunctionalities.Length > 0)
            {
                var response = new ResponseBase<PageAuthorizationOutputVm>(pageAuthorizationOutput, message: SecurityMessages.AUTHORIZED_MSG);
                return Ok(response);
            }
            else
                return Unauthorized(new ResponseBase(HttpStatusCode.Unauthorized, SecurityMessages.UNAUTHORIZED_MSG));
        }
    }
}
