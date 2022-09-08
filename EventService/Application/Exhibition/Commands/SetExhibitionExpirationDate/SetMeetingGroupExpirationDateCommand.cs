using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using Newtonsoft.Json;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.SetExhibitionExpirationDate;

public class SetExhibitionExpirationDateCommand : InternalCommandBase
{
    [JsonConstructor]
    public SetExhibitionExpirationDateCommand(Guid id, Guid ExhibitionId, DateTime dateTo)
        : base(id)
    {
        ExhibitionId = ExhibitionId;
        DateTo = dateTo;
    }

    internal Guid ExhibitionId { get; }

    internal DateTime DateTo { get; }
}