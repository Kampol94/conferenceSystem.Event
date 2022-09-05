using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.SetEventHostRole;

internal class SetEventHostRoleCommandHandler : ICommandHandler<SetEventHostRoleCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    internal SetEventHostRoleCommandHandler(
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
        var @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        var exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        @event.SetHostRole(exhibition, _memberContext.MemberId, new MemberId(request.MemberId));

        return Unit.Value;
    }
}