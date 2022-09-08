using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.RemoveEventParticipant;

public class RemoveEventParticipantCommand : CommandBase
{
    public RemoveEventParticipantCommand(Guid eventId, Guid participantId, string removingReason)
    {
        EventId = eventId;
        ParticipantId = participantId;
        RemovingReason = removingReason;
    }

    public Guid EventId { get; }

    public Guid ParticipantId { get; }

    public string RemovingReason { get; }
}