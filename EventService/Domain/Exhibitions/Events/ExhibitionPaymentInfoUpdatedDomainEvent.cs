using EventService.Domain.Contracts;

namespace EventService.Domain.Exhibitions.Events;

public class ExhibitionPaymentInfoUpdatedDomainEvent : DomainEventBase
{
    public ExhibitionPaymentInfoUpdatedDomainEvent(ExhibitionId exhibitionId, DateTime paymentDateTo)
    {
        ExhibitionId = exhibitionId;
        PaymentDateTo = paymentDateTo;
    }

    public ExhibitionId ExhibitionId { get; }

    public DateTime PaymentDateTo { get; }
}