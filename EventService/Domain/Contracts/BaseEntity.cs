using EventService.Domain.Contracts.Exceptions;
using MediatR;

namespace EventService.Domain.Contracts;

public abstract class BaseEntity
{
    private readonly IMediator mediator;

    public BaseEntity(IMediator mediator)
    {
            this.mediator = mediator;
        
    }
    protected void AddDomainEvent(IBaseDomainEvent domainDomainEvent)
    {
        mediator.Send(domainDomainEvent);
    }

    protected static void CheckRule(IBaseBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}