using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class OnlyEventOrExhibitionOrganizerCanSetEventMemberRolesRule : IBaseBusinessRule
{
    private readonly MemberId _settingMemberId;
    private readonly Exhibition _exhibition;
    private readonly List<EventParticipant> _participants;

    public OnlyEventOrExhibitionOrganizerCanSetEventMemberRolesRule(MemberId settingMemberId, Exhibition exhibition, List<EventParticipant> participants)
    {
        _settingMemberId = settingMemberId;
        _exhibition = exhibition;
        _participants = participants;
    }

    public bool IsBroken()
    {
        EventParticipant? settingMember = _participants.SingleOrDefault(x => x.IsActiveParticipant(_settingMemberId));

        bool isHost = settingMember != null && settingMember.IsActiveHost();
        bool isOrganizer = _exhibition.IsOrganizer(_settingMemberId);

        return !isHost && !isOrganizer;
    }

    public string Message => "Only event host or exhibition organizer can set event member roles";
}