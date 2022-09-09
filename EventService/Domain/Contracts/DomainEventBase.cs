namespace EventService.Domain.Contracts;
public abstract class DomainEventBase : IBaseDomainEvent
{
    public Guid Id { get; }

    public DateTime When { get; }

    public DomainEventBase()
    {
        Id = Guid.NewGuid();
        When = DateTime.UtcNow; // TODO: add time provider 
    }
}
