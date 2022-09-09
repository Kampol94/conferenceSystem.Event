using EventService.Domain.Contracts.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Domain.Contracts;

public abstract class BaseEntity
{
    private readonly IMediator mediator = (new ServiceCollection()).BuildServiceProvider().GetRequiredService<IMediator>(); //TODO: fix this anti pattern 

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