using CompanyName.MyEvents.Modules.Events.Application.Events.GetEventParticipants;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.GetEventParticipants;

public class GetEventParticipantsQuery : QueryBase<List<GetEventParticipantsRespone>>
{
    public GetEventParticipantsQuery(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}