using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.MeetingComments;
using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.MeetingGroupProposals;
using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Meetings;
using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Members;
using CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Members.MemberSubscriptions;
using EventService.Domain.ConferenceSubscriptions;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) //, IWebHostEnvironment environment)
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
            services.AddTransient<IMemberRepository, MemberRepository>();

            return services;
        }
    }
}
