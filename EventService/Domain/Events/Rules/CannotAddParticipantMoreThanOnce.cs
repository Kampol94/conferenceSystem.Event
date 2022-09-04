using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class CannotAddParticipantMoreThenOnce : IBaseBusinessRule
{
    private readonly MemberId _participantId;

    private readonly List<EventParticipant> _participants;

    public CannotAddParticipantMoreThenOnce(MemberId participantId, List<EventParticipant> participants)
    {
        _participantId = participantId;
        _participants = participants;
    }

    public bool IsBroken() => _participants.SingleOrDefault(x => x.IsActiveParticipant(_participantId)) != null;

    public string Message => "Member is already added to this event";
}