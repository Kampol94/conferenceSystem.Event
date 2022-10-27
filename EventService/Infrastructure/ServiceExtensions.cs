using EventService.Application.Contracts;
using EventService.Application.Emails;
using EventService.Domain.ConferenceSubscriptions;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using EventService.Infrastructure.Domain.ConferenceSubscriptions;
using EventService.Infrastructure.Domain.EventReviews;
using EventService.Infrastructure.Domain.Events;
using EventService.Infrastructure.Domain.ExhibitionProposals;
using EventService.Infrastructure.Domain.Exhibitions;
using EventService.Infrastructure.Domain.Members;
using EventService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventService.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration != null)
        {
            _ = services.AddDbContext<EventsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        _ = services.AddTransient<IEventRepository, EventRepository>();
        _ = services.AddTransient<IConferenceSubscriptionRepository, ConferenceSubscriptionRepository>();
        _ = services.AddTransient<IEventReviewRepository, EventReviewRepository>();
        _ = services.AddTransient<IExhibitionProposalRepository, ExhibitionProposalRepository>();
        _ = services.AddTransient<IExhibitionRepository, ExhibitionRepository>();
        _ = services.AddTransient<IMemberRepository, MemberRepository>();
        _ = services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>(x => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
        _ = services.AddTransient<IEmailSender, EmailSender>();
        _ = services.AddTransient<IEventBus, EventBus>();

        return services;
    }
}
