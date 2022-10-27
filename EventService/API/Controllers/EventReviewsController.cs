using EventService.Application.EventReviews.Commands.AddEventReview;
using EventService.Application.EventReviews.Commands.AddEventReviewtReply;
using EventService.Application.EventReviews.Commands.EditEventReview;
using EventService.Application.EventReviews.Commands.RemoveEventReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventService.API.Controllers;

[ApiController]
public class EventReviewsController : BaseApiController
{
    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddEventReview([FromBody] AddEventReviewsCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPut("")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> EditEventReview([FromBody] EditEventReviewsCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveEventReview([FromBody] RemoveEventReviewsCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpPost("{meetingCommentId}/replies")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddReply([FromBody] AddReplyToEventReviewsCommand request)
    {
        return Ok(await Mediator.Send(request));
    }
}
