using EventService.Domain.ConferenceSubscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.ConferenceSubscriptions;

public class ConferenceSubscriptionEntityTypeConfiguration : IEntityTypeConfiguration<ConferenceSubscription>
{
    public void Configure(EntityTypeBuilder<ConferenceSubscription> builder)
    {
        _ = builder.ToTable("ConferenceSubscriptions", "events");

        _ = builder.Property<ConferenceSubscriptionId>("Id").HasConversion(v => v.Value, c => new ConferenceSubscriptionId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property("_expirationDate").HasColumnName("ExpirationDate");
    }
}
