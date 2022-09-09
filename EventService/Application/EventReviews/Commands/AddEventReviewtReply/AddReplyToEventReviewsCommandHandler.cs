using EventService.Application.Contracts.Commands;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Application.EventReviews.Commands.AddEventReviewtReply;

public class AddReplyToEventReviewsCommandHandler : ICommandHandler<AddReplyToEventReviewsCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventReviewRepository _eventReviewsRepository;
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    public AddReplyToEventReviewsCommandHandler(
        IEventRepository eventRepository,
        IEventReviewRepository eventReviewsRepository,
        IExhibitionRepository exhibitionRepository,
        IMemberContext memberContext)
    {
        _exhibitionRepository = exhibitionRepository;
        _eventRepository = eventRepository;
        _eventReviewsRepository = eventReviewsRepository;
        _memberContext = memberContext;
    }

    public async Task<Guid> Handle(AddReplyToEventReviewsCommand command, CancellationToken cancellationToken)
    {
        var eventReviews = await _eventReviewsRepository.GetByIdAsync(new EventReviewId(command.InReplyToEventReviewId));
        if (eventReviews == null)
        {
            throw new Exception("To create reply the review must exist." );
        }

        var meeting = await _eventRepository.GetByIdAsync(eventReviews.GetEventId());

        var meetingGroup = await _exhibitionRepository.GetByIdAsync(meeting.GetExhibitionId());

        var reply = eventReviews.Reply(_memberContext.MemberId, command.Reply, meetingGroup);
        await _eventReviewsRepository.AddAsync(reply);

        return reply.Id.Value;
    }
}