using System.Reflection;
using EventService.Application.Members;
using EventService.Domain.Members;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient<IMemberContext, MemberContext>();
        return services;
    }
}
