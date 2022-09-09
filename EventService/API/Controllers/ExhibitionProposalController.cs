using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class ExhibitionProposalController : BaseApiController
{
    [HttpPut]
    //internal from managment service
    public async Task<ActionResult> AcceptExhibitionProposal([FromBody] AcceptExhibitionProposalCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
