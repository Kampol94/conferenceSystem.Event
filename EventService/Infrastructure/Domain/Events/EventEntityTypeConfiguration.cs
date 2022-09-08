using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Meetings;

internal class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events", "events");

        builder.HasKey(x => x.Id);

        builder.Property<ExhibitionId>("_exhibitionId").HasColumnName("ExhibitionId");
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<MemberId>("_creatorId").HasColumnName("CreatorId");
        builder.Property<MemberId>("_changeMemberId").HasColumnName("ChangeMemberId");
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime?>("_changeDate").HasColumnName("ChangeDate");
        builder.Property<DateTime?>("_cancelDate").HasColumnName("CancelDate");
        builder.Property<bool>("_isCanceled").HasColumnName("IsCanceled");
        builder.Property<MemberId>("_cancelMemberId").HasColumnName("CancelMemberId");

        builder.OwnsOne(x => x.Time, b =>
        {
            b.Property(p => p.StartDate).HasColumnName("TermStartDate");
            b.Property(p => p.EndDate).HasColumnName("TermEndDate");
        });

        builder.OwnsOne<RsvpTime>("_rsvpTerm", b =>
        {
            b.Property(p => p.StartDate).HasColumnName("RSVPTermStartDate");
            b.Property(p => p.EndDate).HasColumnName("RSVPTermEndDate");
        });

        builder.OwnsOne<Money>("_eventFee", b =>
        {
            b.Property(p => p.Value).HasColumnName("EventFeeValue");
            b.Property(p => p.Currency).HasColumnName("EventFeeCurrency");
        });

        builder.OwnsMany<EventParticipant>("_participants", y =>
        {
            y.WithOwner().HasForeignKey("EventId");
            y.ToTable("EventParticipants", "events");
            y.Property<MemberId>("ParticipantId");
            y.Property<EventId>("EventId");
            y.Property<DateTime>("_decisionDate").HasColumnName("DecisionDate");
            y.HasKey("ParticipantId", "EventId", "_decisionDate");
            y.Property<bool>("_decisionChanged").HasColumnName("DecisionChanged");
            y.Property<DateTime?>("_decisionChangeDate").HasColumnName("DecisionChangeDate");
            y.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
            y.Property<string>("_removingReason").HasColumnName("RemovingReason");
            y.Property<MemberId>("_removingMemberId").HasColumnName("RemovingMemberId");
            y.Property<DateTime?>("_removedDate").HasColumnName("RemovedDate");
            y.Property<bool>("_isFeePaid").HasColumnName("IsFeePaid");

            y.OwnsOne<EventParticipantRole>("_role", b =>
            {
                b.Property(x => x.Value).HasColumnName("RoleCode");
            });

            y.OwnsOne<Money>("_fee", b =>
            {
                b.Property(p => p.Value).HasColumnName("FeeValue");
                b.Property(p => p.Currency).HasColumnName("FeeCurrency");
            });
        });

        builder.OwnsMany<EventWaitlistMember>("_waitlistMembers", y =>
        {
            y.WithOwner().HasForeignKey("EventId");
            y.ToTable("EventWaitlistMembers", "events");
            y.Property<MemberId>("MemberId");
            y.Property<EventId>("EventId");
            y.Property<DateTime>("SignUpDate").HasColumnName("SignUpDate");
            y.HasKey("MemberId", "MeetingId", "SignUpDate");
            y.Property<bool>("_isSignedOff").HasColumnName("IsSignedOff");
            y.Property<DateTime?>("_signOffDate").HasColumnName("SignOffDate");

            y.Property<bool>("_isMovedToParticipants").HasColumnName("IsMovedToParticipants");
            y.Property<DateTime?>("_movedToParticipantsDate").HasColumnName("MovedToParticipantsDate");
        });

        builder.OwnsOne<EventLimits>("_eventLimits", meetingLimits =>
        {
            meetingLimits.Property(x => x.ParticipantsLimit).HasColumnName("AttendeesLimit");
        });
    }
}
