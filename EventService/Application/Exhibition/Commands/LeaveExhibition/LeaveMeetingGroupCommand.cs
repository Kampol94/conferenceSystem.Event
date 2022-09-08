using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.LeaveExhibition;

public class LeaveExhibitionCommand : CommandBase
{
    public LeaveExhibitionCommand(Guid ExhibitionId)
    {
        ExhibitionId = ExhibitionId;
    }

    internal Guid ExhibitionId { get; }
}