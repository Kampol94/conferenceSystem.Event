using EventService.Domain.ConferenceSubscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Members.MemberSubscriptions;

internal class ConferenceSubscriptionEntityTypeConfiguration : IEntityTypeConfiguration<ConferenceSubscription>
{
    public void Configure(EntityTypeBuilder<ConferenceSubscription> builder)
    {
        builder.ToTable("ConferenceSubscriptions", "events");

        builder.HasKey(x => x.Id);

        builder.Property("_expirationDate").HasColumnName("ExpirationDate");
    }
}
