namespace EventService.Domain.Contracts;
public abstract class DomainEventBase : IBaseDomainEvent
{
    public Guid Id { get; }

    public DateTime When { get; }

    public DomainEventBase()
    {
        this.Id = Guid.NewGuid();
        this.When = DateTime.UtcNow; // TODO: add time provider 
    }
}
