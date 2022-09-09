using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Application.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, Guid>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    public CreateEventCommandHandler(
        IMemberContext memberContext,
        IEventRepository eventRepository,
        IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var exhibition = await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        var hostsMembersIds = request.HostMemberIds.Select(x => new MemberId(x)).ToList();

        var @event = exhibition.CreateEvent(
            request.Title,
            EventTime.CreateNewBetweenDates(request.TermStartDate, request.TermStartDate),
            request.Description,
            request.ParticipantsLimit,
            RsvpTime.CreateNewBetweenDates(request.RSVPTermStartDate, request.RSVPTermEndDate),
            request.EventFeeValue.HasValue? Money.Of(request.EventFeeValue.Value, request.EventFeeCurrency) : Money.Undefined,
            hostsMembersIds,
            _memberContext.MemberId);

        await _eventRepository.AddAsync(@event);

        return @event.Id.Value;
    }
}