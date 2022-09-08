using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.JoinToGroup;

public class JoinToGroupCommand : CommandBase
{
    public JoinToGroupCommand(Guid ExhibitionId)
    {
        ExhibitionId = ExhibitionId;
    }

    internal Guid ExhibitionId { get; }
}