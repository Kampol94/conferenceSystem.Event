using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.MarkEventParticipantFeeAsPayed;

internal class MarkEventParticipantFeeAsPayedCommandHandler : ICommandHandler<MarkEventParticipantFeeAsPayedCommand>
{
    private readonly IEventRepository _eventRepository;

    public MarkEventParticipantFeeAsPayedCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(MarkEventParticipantFeeAsPayedCommand command, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(new EventId(command.EventId));

        @event.MarkParticipantFeeAsPayed(new MemberId(command.MemberId));

        return Unit.Value;
    }
}