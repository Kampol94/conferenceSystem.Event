using CompanyName.MyEvents.Modules.Events.Application.Events.CancelEvent;
using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.CancelEvent;

internal class CancelEventCommandHandler : ICommandHandler<CancelEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMemberContext _memberContext;

    internal CancelEventCommandHandler(IEventRepository eventRepository, IMemberContext memberContext)
    {
        _eventRepository = eventRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        @event.Cancel(_memberContext.MemberId);

        return Unit.Value;
    }
