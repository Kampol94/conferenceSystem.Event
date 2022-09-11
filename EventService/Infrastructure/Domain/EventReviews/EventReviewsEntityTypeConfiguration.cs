﻿using EventService.Domain.EventReviews;
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

        builder.Property<EventReviewId>("Id").HasConversion(v => v.Value, c => new EventReviewId(c));
        builder.HasKey("Id");

        builder.Property<string>("_text").HasColumnName("Text");
        builder.Property<EventId>("_eventId").HasColumnName("EventId").HasConversion(v => v.Value, c => new EventId(c));
        builder.Property<MemberId>("_authorId").HasColumnName("AuthorId").HasConversion(v => v.Value, c => new MemberId(c)); ;
        builder.Property<EventReviewId>("_inReplyToReviewId").HasColumnName("InReplyToReviewId").HasConversion(v => v.Value, c => new EventReviewId(c)); ;
        builder.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
        builder.Property<string>("_removedByReason").HasColumnName("RemovedByReason");
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime?>("_editDate").HasColumnName("EditDate");
    }
}