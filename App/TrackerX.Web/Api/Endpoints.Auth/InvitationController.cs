using Microsoft.AspNetCore.Mvc;
using TrackerX.Services.Accounts.Invitations;
using TrackerX.Services.Accounts.Invitations.Models;

namespace TrackerX.Web.Api.Gateway.Account
{
    [ApiController]
    [Route("api/account/invitation")]
    public class InvitationController : Controller
    {
        private readonly IInvitationService _invitationService;

        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [HttpGet]
        [Route("v1/list")]
        [ProducesResponseType(typeof(IEnumerable<InvitationModel>), 200)]
        public async Task<IActionResult> Get(bool includeAccepted, bool includeAborted)
        {
            var result = await _invitationService.GetInvitationListAsync(includeAccepted, includeAborted);

            return Ok(result);
        }

        [HttpPost]
        [Route("v1/create")]
        public async Task<IActionResult> CreateInvitation(string code, DateTime? dueTo)
        {
            await _invitationService.CreateInvitationAsync(code, dueTo);

            return Ok();
        }

        [HttpPut]
        [Route("v1/abort")]
        public async Task<IActionResult> AbortInvitation(int invitationId)
        {
            await _invitationService.AbortInvitationAsync(invitationId);

            return Ok();
        }
    }
}
