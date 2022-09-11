﻿using EventService.Application.Contracts.Commands;
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
        EventReview? exhibition = await _eventReviewsRepository.GetByIdAsync(new EventReviewId(command.EventReviewsId));
        if (exhibition == null)
        {
            throw new Exception("Meeting comment for removing must exist.");
        }

        Event? @event = await _eventRepository.GetByIdAsync(exhibition.GetEventId());
        Exhibition? meetingGroup = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        exhibition.Remove(_memberContext.MemberId, meetingGroup, command.Reason);

        return Unit.Value;
    }
}