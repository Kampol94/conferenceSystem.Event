using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Newtonsoft.Json;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.SendExhibitionCreatedEmail;

internal class SendExhibitionCreatedEmailCommand : InternalCommandBase
{
    internal ExhibitionId ExhibitionId { get; }

    internal MemberId CreatorId { get; }

    [JsonConstructor]
    internal SendExhibitionCreatedEmailCommand(Guid id, ExhibitionId ExhibitionId, MemberId creatorId)
        : base(id)
    {
        ExhibitionId = ExhibitionId;
        CreatorId = creatorId;
    }
}