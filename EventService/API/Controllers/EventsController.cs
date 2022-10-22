using EventService.Application.Events.Commands.CancelEvent;
using EventService.Application.Events.Commands.ChangeEventMainAttributes;
using EventService.Application.Events.Commands.CreateEvent;
using EventService.Application.Events.Commands.RegisterToEvent;
using EventService.Application.Events.Commands.RemoveEventParticipant;
using EventService.Application.Events.Commands.SetEventHostRole;
using EventService.Application.Events.Commands.SetEventParticipantRole;
using EventService.Application.Events.Commands.SignOffFromWaitlist;
using EventService.Application.Events.Commands.SignUpToWaitlist;
using EventService.Application.Events.Query.GetEventDetails;
using EventService.Application.Events.Query.GetEventParticipants;
using EventService.Application.Events.Query.GetParticipantEventsInWhichTakesPart;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

public class EventsController : BaseApiController
{
    [HttpGet("")]
    [ProducesResponseType(typeof(List<GetParticipantEventsInWhichTakesPartResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetParticipantEventsInWhichTakesPart()
    {
        return Ok(await Mediator.Send(new GetParticipantEventsInWhichTakesPartQuery()));
    }

    [HttpGet("{eventId}")]
    [ProducesResponseType(typeof(GetEventDetailsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEventDetails([FromRoute] Guid eventId)
    {
        return Ok(await Mediator.Send(new GetEventDetailsQuery(eventId)));
    }


    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
    

    [HttpPut("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditMeeting([FromBody] ChangeEventMainAttributesCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpGet("attendees/{eventId}")]
    [ProducesResponseType(typeof(List<GetEventParticipantsResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEventParticipants([FromRoute] Guid eventId)
    {
        return Ok(await Mediator.Send(new GetEventParticipantsQuery(eventId)));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RegisterToEvent([FromBody] RegisterToEventCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("participant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveEventParticipant([FromBody] RemoveEventParticipantCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPost("waitlistMembers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SignUpToWaitlist([FromBody] SignUpToWaitlistCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("waitlistMembers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SignOffMemberFromWaitlist([FromBody] SignOffFromWaitlistCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPost("hosts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetEventHostRole([FromBody] SetEventHostRoleCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPost("attendees/attendeeRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetEventParticipantRole([FromBody] SetEventParticipantRoleCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPatch("cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CancelEvent([FromBody] CancelEventCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
}