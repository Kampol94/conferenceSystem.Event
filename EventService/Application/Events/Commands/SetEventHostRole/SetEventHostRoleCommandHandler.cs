using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.SetEventHostRole;

public class SetEventHostRoleCommandHandler : ICommandHandler<SetEventHostRoleCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    public SetEventHostRoleCommandHandler(
        IMemberContext memberContext,
        IEventRepository eventRepository,
        IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(SetEventHostRoleCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        @event.SetHostRole(exhibition, _memberContext.MemberId, new MemberId(request.MemberId));

        return Unit.Value;
    }
}