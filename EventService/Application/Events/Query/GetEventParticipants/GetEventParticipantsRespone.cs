namespace EventService.Application.Events.Query.GetEventParticipants;

public class GetEventParticipantsResponse
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Guid ParticipantId { get; set; }

    public string? RoleCode { get; set; }

    public DateTime DecisionDate { get; set; }
}