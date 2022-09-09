using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.ChangeEventMainAttributes;

public class ChangeEventMainAttributesCommandHandler : ICommandHandler<ChangeEventMainAttributesCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;

    public ChangeEventMainAttributesCommandHandler(IMemberContext memberContext, IEventRepository eventRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(ChangeEventMainAttributesCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        @event.ChangeMainAttributes(
            request.Title,
            EventTime.CreateNewBetweenDates(request.TermStartDate, request.TermStartDate),
            request.Description,
            EventLimits.Create(request.ParticipantsLimit),
            RsvpTime.CreateNewBetweenDates(request.RSVPTermStartDate, request.RSVPTermEndDate),
            request.EventFeeValue.HasValue ? Money.Of(request.EventFeeValue.Value, request.EventFeeCurrency) : Money.Undefined,
            _memberContext.MemberId);

        return Unit.Value;
    }
}
