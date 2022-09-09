using EventService.Domain.Contracts.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventService.Domain.Contracts;

public abstract class BaseEntity
{
    private readonly IMediator _mediator = new ServiceCollection().AddMediatR(Assembly.GetExecutingAssembly()).BuildServiceProvider().GetRequiredService<IMediator>(); //TODO: fix this anti pattern 

    protected void AddDomainEvent(IBaseDomainEvent domainDomainEvent)
    {
        _mediator.Publish(domainDomainEvent);
    }

    protected static void CheckRule(IBaseBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}