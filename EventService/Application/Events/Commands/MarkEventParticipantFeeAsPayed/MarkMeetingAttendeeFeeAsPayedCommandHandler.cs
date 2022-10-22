using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.MarkEventParticipantFeeAsPayed;

public class MarkEventParticipantFeeAsPayedCommandHandler : ICommandHandler<MarkEventParticipantFeeAsPayedCommand>
{
    private readonly IEventRepository _eventRepository;

    public MarkEventParticipantFeeAsPayedCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(MarkEventParticipantFeeAsPayedCommand command, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(command.EventId));

        if (@event is null)
        {
            throw new Exception("Event must exist."); // TODO: custom exception
        }

        @event.MarkParticipantFeeAsPayed(new MemberId(command.MemberId));

        return Unit.Value;
    }
}