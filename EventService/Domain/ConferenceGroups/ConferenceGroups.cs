using EventService.Domain.Members;

namespace EventService.Domain.ConferenceGroups;

public class ConferenceGroup
{
    internal bool IsMemberOfGroup(MemberId participantId)
    {
        throw new NotImplementedException();
    }

    internal bool IsOrganizer(MemberId settingMemberId)
    {
        throw new NotImplementedException();
    }
}