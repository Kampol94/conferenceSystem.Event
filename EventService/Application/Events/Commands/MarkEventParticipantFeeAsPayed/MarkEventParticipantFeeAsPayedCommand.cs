using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.MarkEventParticipantFeeAsPayed;

public class MarkEventParticipantFeeAsPayedCommand : CommandBase
{
    public MarkEventParticipantFeeAsPayedCommand(Guid id, Guid memberId, Guid eventId)
        : base(id)
    {
        MemberId = memberId;

        EventId = eventId;
    }

    public Guid MemberId { get; }

    public Guid EventId { get; }
}