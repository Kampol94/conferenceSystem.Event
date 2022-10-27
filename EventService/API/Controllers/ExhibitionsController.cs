using EventService.Application.Exhibitions.Commands.EditExhibitionGeneralAttributes;
using EventService.Application.Exhibitions.Commands.JoinToExhibition;
using EventService.Application.Exhibitions.Commands.LeaveExhibition;
using EventService.Application.Exhibitions.Queries.GetAllExhibitions;
using EventService.Application.Exhibitions.Queries.GetAuthenticationMemberExhibition;
using EventService.Application.Exhibitions.Queries.GetExhibitionDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

[ApiController]
public class ExhibitionsController : BaseApiController
{
    [HttpGet("")]
    [Authorize]
    [ProducesResponseType(typeof(List<MemberExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthenticationMemberExhibitions()
    {
        return Ok(await Mediator.Send(new GetAuthenticationMemberExhibitionsQuery()));
    }

    [HttpGet("{exhibitionId}")]
    public async Task<IActionResult> GetExhibitionDetails(Guid exhibitionId)
    {
        return Ok(await Mediator.Send(new GetExhibitionDetailsQuery(exhibitionId)));
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<ExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllExhibitions()
    {
        return Ok(await Mediator.Send(new GetAllExhibitionsQuery()));
    }

    [HttpPut("")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditExhibitionGeneralAttributes([FromBody] EditExhibitionGeneralAttributesCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPost("members")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> JoinToExhibition([FromBody] JoinToExhibitionCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("members")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> LeaveExhibition([FromBody] LeaveExhibitionCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
}