using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Service.Musics.Models;
using TrackerX.Service.Proposals;
using TrackerX.Service.Proposals.Models;

namespace TrackerX.Web.Api.Gateway;

[ApiController]
[Route("api/v1/proposal")]
[Authorize]
public class ProposalController : Controller
{
    private readonly IProposalService _proposalService;

    public ProposalController(IProposalService proposalService)
    {
        _proposalService = proposalService;       
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<MusicProfileView>), 200)]
    public async Task<IActionResult> Get([FromQuery] ProposalSearchArgs searchModel)
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await _proposalService.GetUserProposals(searchModel, userId);

        return Ok(result);
    }
}
