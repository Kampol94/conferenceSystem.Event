using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class OnlyActiveParticipantCanBeRemovedFromEventRule : IBaseBusinessRule
{
    private readonly List<EventParticipant> _participants;
    private readonly MemberId _participantId;

    internal OnlyActiveParticipantCanBeRemovedFromEventRule(
        List<EventParticipant> participants,
        MemberId participantId)
    {
        _participants = participants;
        _participantId = participantId;
    }

    public bool IsBroken() => _participants.SingleOrDefault(x => x.IsActiveParticipant(_participantId)) == null;

    public string Message => "Only active participant can be removed from event";
}