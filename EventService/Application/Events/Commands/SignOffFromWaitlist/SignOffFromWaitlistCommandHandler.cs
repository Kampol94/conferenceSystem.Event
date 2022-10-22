using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.SignOffFromWaitlist;

public class SignOffFromWaitlistCommandHandler : ICommandHandler<SignOffFromWaitlistCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;

    public SignOffFromWaitlistCommandHandler(IMemberContext memberContext, IEventRepository eventRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(SignOffFromWaitlistCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        if (@event is null)
        {
            throw new Exception("Event for signoff from wait list must exist."); // TODO: custom exception
        }

        @event.SignOffMemberFromWaitlist(_memberContext.MemberId);

        return Unit.Value;
    }
}