using EventService.Domain.Exceptions;

namespace EventService.Domain.Contracts;

public abstract class BaseEntity
{
    private List<IBaseDomainAction> _domainActions;

    public IReadOnlyCollection<IBaseDomainAction> DomainActions => _domainActions?.AsReadOnly();

    public void ClearDomainActions()
    {
        _domainActions?.Clear();
    }

    protected void AddDomainActions(IBaseDomainAction domainAction)
    {
        _domainActions ??= new List<IBaseDomainAction>();

        this._domainActions.Add(domainAction);
    }

    protected void CheckRule(IBaseBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}