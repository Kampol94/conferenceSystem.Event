using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.EventReviews;

public class EventReviewsEntityTypeConfiguration : IEntityTypeConfiguration<EventReview>
{
    public void Configure(EntityTypeBuilder<EventReview> builder)
    {
        _ = builder.ToTable("EventReviews", "events");

        _ = builder.Property<EventReviewId>("Id").HasConversion(v => v.Value, c => new EventReviewId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property<string>("_text").HasColumnName("Text");
        _ = builder.Property<EventId>("_eventId").HasColumnName("EventId").HasConversion(v => v.Value, c => new EventId(c));
        _ = builder.Property<MemberId>("_authorId").HasColumnName("AuthorId").HasConversion(v => v.Value, c => new MemberId(c)); ;
        _ = builder.Property<EventReviewId>("_inReplyToReviewId").HasColumnName("InReplyToReviewId").HasConversion(v => v.Value, c => new EventReviewId(c)); ;
        _ = builder.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
        _ = builder.Property<string>("_removedByReason").HasColumnName("RemovedByReason");
        _ = builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        _ = builder.Property<DateTime?>("_editDate").HasColumnName("EditDate");
    }
}