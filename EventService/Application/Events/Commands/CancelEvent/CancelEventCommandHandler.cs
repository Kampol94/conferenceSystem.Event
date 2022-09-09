using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.CancelEvent;

public class CancelEventCommandHandler : ICommandHandler<CancelEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMemberContext _memberContext;

    public CancelEventCommandHandler(IEventRepository eventRepository, IMemberContext memberContext)
    {
        _eventRepository = eventRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        @event.Cancel(_memberContext.MemberId);

        return Unit.Value;
    }
}
