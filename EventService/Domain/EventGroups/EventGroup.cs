using EventService.Domain.Members;

namespace EventService.Domain.EventGroups;

public class EventGroup
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