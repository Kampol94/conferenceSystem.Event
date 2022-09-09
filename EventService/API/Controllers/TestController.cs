using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class TestController : BaseApiController
{
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] AcceptExhibitionProposalCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
