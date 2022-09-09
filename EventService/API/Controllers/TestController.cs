using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TestController : BaseApiController
{
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] AcceptExhibitionProposalCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
