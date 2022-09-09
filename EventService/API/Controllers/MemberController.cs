using EventService.Application.Members.CreateMember;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class MemberController : BaseApiController
{
    [HttpPost]
    //internal from managment service
    public async Task<ActionResult> CreateMember([FromBody] CreateMemberCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
