﻿using EventService.Application.Contracts.Commands;
using EventService.Domain.EventReviews;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.EventReviews.Commands.EditEventReview;

internal class EditEventReviewsCommandHandler : ICommandHandler<EditEventReviewsCommand>
{
    private readonly IEventReviewRepository _eventReviewsRepository;
    private readonly IMemberContext _memberContext;

    internal EditEventReviewsCommandHandler(
        IEventReviewRepository eventReviewsRepository,
        IMemberContext memberContext)
    {
        _eventReviewsRepository = eventReviewsRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(EditEventReviewsCommand command, CancellationToken cancellationToken)
    {
        var eventReview = await _eventReviewsRepository.GetByIdAsync(new EventReviewId(command.EventReviewsId));
        if (eventReview == null)
        {
            throw new Exception("Meeting comment for editing must exist.");
        }

        eventReview.Edit(_memberContext.MemberId, command.EditedReview);

        return Unit.Value;
    }
}