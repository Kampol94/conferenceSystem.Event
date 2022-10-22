using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.RemoveEventParticipant;

public class RemoveEventParticipantCommandHandler : ICommandHandler<RemoveEventParticipantCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMemberContext _memberContext;

    public RemoveEventParticipantCommandHandler(IEventRepository eventRepository, IMemberContext memberContext)
    {
        _eventRepository = eventRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(RemoveEventParticipantCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        if (@event is null)
        {
            throw new Exception("Event for removing participant must exist."); // TODO: custom exception
        }

        @event.RemoveParticipant(new MemberId(request.ParticipantId), _memberContext.MemberId, request.RemovingReason);

        return Unit.Value;
    }
}
