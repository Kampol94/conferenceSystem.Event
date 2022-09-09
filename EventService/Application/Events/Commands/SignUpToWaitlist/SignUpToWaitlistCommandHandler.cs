using MediatR;
using EventService.Application.Contracts.Commands;
using EventService.Domain.Members;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;

namespace EventService.Application.Events.Commands.SignUpToWaitlist;

public class SignUpToWaitlistCommandHandler : ICommandHandler<SignUpToWaitlistCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IEventRepository _eventRepository;
    private readonly IExhibitionRepository _exhibitionRepository;

    public SignUpToWaitlistCommandHandler(
        IMemberContext memberContext,
        IEventRepository eventRepository,
        IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _eventRepository = eventRepository;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(SignUpToWaitlistCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        var exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        @event.SignUpMemberToWaitlist(exhibition, _memberContext.MemberId);

        return Unit.Value;
    }
}