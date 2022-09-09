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
        builder.ToTable("EventReviews", "events");

        builder.HasKey(c => c.Id);

        builder.Property<string>("_text").HasColumnName("Text");
        builder.Property<EventId>("_eventId").HasColumnName("EventId");
        builder.Property<MemberId>("_authorId").HasColumnName("AuthorId");
        builder.Property<EventReviewId>("_inReplyToReviewId").HasColumnName("InReplyToReviewId");
        builder.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
        builder.Property<string>("_removedByReason").HasColumnName("RemovedByReason");
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime?>("_editDate").HasColumnName("EditDate");
    }
}