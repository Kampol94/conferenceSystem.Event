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
            services.AddDbContext<EventsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        services.AddTransient<IEventRepository, EventRepository>();
        services.AddTransient<IConferenceSubscriptionRepository, ConferenceSubscriptionRepository>();
        services.AddTransient<IEventReviewRepository, EventReviewRepository>();
        services.AddTransient<IExhibitionProposalRepository, ExhibitionProposalRepository>();
        services.AddTransient<IExhibitionRepository, ExhibitionRepository>();
        services.AddTransient<IMemberRepository, MemberRepository>();
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>(x => new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
