using EventService.Application.Contracts.Commands;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.EventReviews.Commands.RemoveEventReview;

public class RemoveEventReviewsCommandHandler : ICommandHandler<RemoveEventReviewsCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventReviewRepository _eventReviewsRepository;
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    public RemoveEventReviewsCommandHandler(IEventRepository eventRepository,
        IEventReviewRepository eventReviewsRepository,
        IExhibitionRepository exhibitionRepository,
        IMemberContext memberContext)
    {
        _exhibitionRepository = exhibitionRepository;
        _eventRepository = eventRepository;
        _eventReviewsRepository = eventReviewsRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(RemoveEventReviewsCommand command, CancellationToken cancellationToken)
    {
        EventReview? eventReview = await _eventReviewsRepository.GetByIdAsync(new EventReviewId(command.EventReviewsId));
        if (eventReview == null)
        {
            throw new Exception("Review for removing must exist.");
        }

        Event? @event = await _eventRepository.GetByIdAsync(eventReview.GetEventId());

        if (@event is null)
        {
            throw new Exception("Event must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition must exist."); // TODO: custom exception
        }

        eventReview.Remove(_memberContext.MemberId, exhibition, command.Reason);

        return Unit.Value;
    }
}