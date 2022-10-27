using EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;
using EventService.Application.ExhibitionProposals.Queries.GetMemberExhibitionProposals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class ExhibitionProposalsController : BaseApiController
{
    [HttpGet("member")]
    [Authorize]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMemberExhibitionProposals()
    {
        return Ok(await Mediator.Send(new GetMemberExhibitionProposalsQuery()));
    }

    [HttpGet("all")]
    [Authorize]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExhibitionProposals()
    {
        return Ok(await Mediator.Send(new GetMemberExhibitionProposalsQuery()));
    }

    [HttpPost("")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ProposeExhibitionC([FromBody] ProposeExhibitionCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
}
