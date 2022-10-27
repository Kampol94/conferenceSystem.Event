using EventService.Application.Contracts.Commands;
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
        _ = services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));
        _ = services.AddTransient<IMemberContext, MemberContext>();
        return services;
    }
}
