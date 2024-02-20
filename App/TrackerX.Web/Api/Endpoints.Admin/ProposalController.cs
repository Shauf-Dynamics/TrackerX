using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrackerX.Service.Musics.Models;
using TrackerX.Service.Proposals;

namespace TrackerX.Web.Api.Endpoints.Admin;

[ApiController]
[Route("api/v1/admin/proposal")]
[Authorize(Policy = "admin")]
public class ProposalController : Controller
{
    private readonly IProposalService _proposalService;

    public ProposalController(IProposalService proposalService)
    {
        _proposalService = proposalService;
    }

    [HttpPut]
    [Route("accept")]    
    public async Task<IActionResult> Get([FromBody] int proposalId)
    {        
        await _proposalService.AcceptProposal(proposalId);

        return Ok();
    }
}
