using EventService.Application.Contracts.Commands;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

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
        Event? @event = await _eventRepository.GetByIdAsync(new EventId(request.EventId));

        if (@event is null)
        {
            throw new Exception("Event for signup to wait list must exist."); // TODO: custom exception
        }

        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(@event.GetExhibitionId());

        if (exhibition is null)
        {
            throw new Exception("Exhibition for signup to wait list must exist."); // TODO: custom exception
        }

        @event.SignUpMemberToWaitlist(exhibition, _memberContext.MemberId);

        return Unit.Value;
    }
}