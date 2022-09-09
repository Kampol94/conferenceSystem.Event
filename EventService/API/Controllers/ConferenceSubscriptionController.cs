using EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class ConferenceSubscriptionController : BaseApiController
{
    [HttpPut]
    //internal from managment service
    public async Task<ActionResult> ChangeSubscriptionExpirationDateForMember([FromBody] ChangeSubscriptionExpirationDateForMemberCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
