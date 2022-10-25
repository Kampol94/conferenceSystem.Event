using EventService.Application.Contracts;

namespace EventService.Application.IntegrationEvents.Events;

public class ExhibitionProposalAcceptedIntegrationEvent : IntegrationEvent
{
    public ExhibitionProposalAcceptedIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid exhibitionProposalId)
        : base(id, occurredOn)
    {
        ExhibitionProposalId = exhibitionProposalId;
    }

    public Guid ExhibitionProposalId { get; }
}