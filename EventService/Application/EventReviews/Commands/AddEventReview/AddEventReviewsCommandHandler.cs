using EventService.Application.Contracts.Commands;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

public class AddEventReviewsCommandHandler : ICommandHandler<AddEventReviewsCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventReviewRepository _eventReviewsRepository;
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    public AddEventReviewsCommandHandler(
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

    public async Task<Guid> Handle(AddEventReviewsCommand command, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(command.EventId));
        if (@event == null)
        {
            throw new Exception("Event for adding comment must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition for adding comment must exist"); // TODO: custom exception
        }

        EventReview eventReviews = @event.AddReview(_memberContext.MemberId, command.Comment, exhibition);

        await _eventReviewsRepository.AddAsync(eventReviews);

        return eventReviews.Id.Value;
    }
}