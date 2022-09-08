using System;
using CompanyName.MyMeetings.BuildingBlocks.Application.Events;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions.Events;
using Newtonsoft.Json;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions;

public class ExhibitionCreatedNotification : DomainNotificationBase<ExhibitionCreatedDomainEvent>
{
    [JsonConstructor]
    internal ExhibitionCreatedNotification(ExhibitionCreatedDomainEvent domainEvent, Guid id)
        : base(domainEvent, id)
    {
    }
}