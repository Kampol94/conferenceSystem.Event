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
        EventReview? eventReviews = await _eventReviewsRepository.GetByIdAsync(new EventReviewId(command.InReplyToEventReviewId));
        if (eventReviews == null)
        {
            throw new Exception("To create reply the review must exist.");
        }

        Event? @event = await _eventRepository.GetByIdAsync(eventReviews.GetEventId());

        if (@event is null)
        {
            throw new Exception("Event must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition must exist."); // TODO: custom exception
        }

        EventReview reply = eventReviews.Reply(_memberContext.MemberId, command.Reply, exhibition);
        await _eventReviewsRepository.AddAsync(reply);

        return reply.Id.Value;
    }
}