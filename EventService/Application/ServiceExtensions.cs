using EventService.Application.Contracts;
using EventService.Application.Contracts.Commands;
using EventService.Application.IntegrationEvents.EventHandlings;
using EventService.Application.IntegrationEvents.Events;
using EventService.Application.Members;
using EventService.Domain.Members;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventService.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        _ = services.AddMediatR(Assembly.GetExecutingAssembly());
        _ = services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        _ = services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandHandlerDecorator<,>));
        _ = services.AddTransient<IMemberContext, MemberContext>();
        services.AddTransient<IIntegrationEventHandler<EventFeePaidIntegrationEvent>, EventFeePaidIntegrationEventHandler>();
        services.AddTransient<IIntegrationEventHandler<ExhibitionProposalAcceptedIntegrationEvent>, ExhibitionProposalAcceptedIntegrationEventHandler>();
        services.AddTransient<IIntegrationEventHandler<SubscriptionExpirationDateChangedIntegrationEvent>, SubscriptionExpirationDateChangedIntegrationEventHandler>();
        services.AddTransient<IIntegrationEventHandler<NewUserRegisteredIntegrationEvent>, NewUserRegisteredIntegrationEventHandler>();

        return services;
    }
}
