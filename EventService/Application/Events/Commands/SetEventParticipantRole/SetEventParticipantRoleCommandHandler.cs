using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.SetEventParticipantRole;

public class SetEventParticipantRoleCommandHandler : ICommandHandler<SetEventParticipantRoleCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    public SetEventParticipantRoleCommandHandler(
        IMemberContext memberContext,
        IEventRepository eventRepository,
        IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(SetEventParticipantRoleCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        if (@event is null)
        {
            throw new Exception("Event must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition must exist."); // TODO: custom exception
        }

        @event.SetParticipantRole(exhibition, _memberContext.MemberId, new MemberId(request.MemberId));

        return Unit.Value;
    }
}