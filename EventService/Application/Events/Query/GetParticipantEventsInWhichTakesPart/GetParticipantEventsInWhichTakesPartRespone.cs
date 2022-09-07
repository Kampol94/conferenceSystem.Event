using System;

namespace EventService.Application.Events.Query.GetParticipantEventsInWhichTakesPart;

public class GetParticipantEventsInWhichTakesPartRespone
{
    public Guid EventId { get; set; }

    public string? Title { get; set; }

    public DateTime TermStartDate { get; set; }

    public DateTime TermEndDate { get; set; }

    public string? RoleCode { get; set; }
}