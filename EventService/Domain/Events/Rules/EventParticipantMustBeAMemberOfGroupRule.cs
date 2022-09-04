using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class EventParticipantMustBeAMemberOfExhibitionRule : IBaseBusinessRule
{
    private readonly Exhibition _exhibition;

    private readonly MemberId _participantId;

    internal EventParticipantMustBeAMemberOfExhibitionRule(MemberId participantId, Exhibition exhibition)
    {
        _participantId = participantId;
        _exhibition = exhibition;
    }

    public bool IsBroken()
    {
        return !_exhibition.IsMemberOfGroup(_participantId);
    }

    public string Message => "Event participant must be a member of exhibition";
}