﻿using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetEventParticipants;

public class GetEventParticipantsQuery : QueryBase<List<GetEventParticipantsRespone>>
{
    public GetEventParticipantsQuery(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}