using EventService.Domain.Contracts.Exceptions;

namespace EventService.Domain.Contracts;

public abstract class BaseEntity
{
    private List<IBaseDomainEvent>? _domainDomainEvents;

    public IReadOnlyCollection<IBaseDomainEvent>? DomainEvents => _domainDomainEvents?.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainDomainEvents?.Clear();
    }

    protected void AddDomainEvent(IBaseDomainEvent domainDomainEvent)
    {
        _domainDomainEvents ??= new List<IBaseDomainEvent>();

        this._domainDomainEvents.Add(domainDomainEvent);
    }

    protected static void CheckRule(IBaseBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}