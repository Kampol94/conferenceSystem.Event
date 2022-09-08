using EventService.Application.Contracts.Commands;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

internal class AddEventReviewsCommandHandler : ICommandHandler<AddEventReviewsCommand, Guid>
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
        var @event = await _eventRepository.GetByIdAsync(new EventId(command.EventId));
        if (@event == null)
        {
            throw new Exception("Meeting for adding comment must exist." ); // TODO: custom exception
        }

        var exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        var eventReviews = @event.AddReview(_memberContext.MemberId, command.Comment, exhibition);

        await _eventReviewsRepository.AddAsync(eventReviews);

        return eventReviews.Id.Value;
    }
}