using EventService.Application.Contracts.Commands;
using EventService.Application.Events.Commands.RegisterToEvent;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.Commands.AddEventParticipant;

internal class RegisterToEventCommandHandler : ICommandHandler<RegisterToEventCommand>
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
        var @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        var exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        @event.AddParticipant(exhibition, _memberContext.MemberId);

        return Unit.Value;
    }
}