using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.RegisterToEvent;

public class RegisterToEventCommandHandler : ICommandHandler<RegisterToEventCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    public RegisterToEventCommandHandler(
        IMemberContext memberContext,
        IEventRepository eventRepository,
        IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(RegisterToEventCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        if (@event is null)
        {
            throw new Exception("Event for registration must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition for registration must exist."); // TODO: custom exception
        }

        @event.AddParticipant(exhibition, _memberContext.MemberId);

        return Unit.Value;
    }
}