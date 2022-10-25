using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;
using Microsoft.AspNetCore.Mvc;
using EventService.Application.ExhibitionProposals.Queries.GetMemberExhibitionProposals;
using EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;

namespace EventService.API.Controllers;

public class ExhibitionProposalsController : BaseApiController
{
    [HttpGet("member")]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMemberExhibitionProposals()
    {
        return Ok(await Mediator.Send(new GetMemberExhibitionProposalsQuery()));
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<ExhibitionProposalDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExhibitionProposals()
    {
        return Ok(await Mediator.Send(new GetMemberExhibitionProposalsQuery()));
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ProposeExhibitionC([FromBody] ProposeExhibitionCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
}
