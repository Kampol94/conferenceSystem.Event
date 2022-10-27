using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.Events;

public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        _ = builder.ToTable("Events", "events");

        _ = builder.Property<EventId>("Id").HasConversion(v => v.Value, c => new EventId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property<ExhibitionId>("_exhibitionId").HasColumnName("ExhibitionId").HasConversion(v => v.Value, c => new ExhibitionId(c)); ;
        _ = builder.Property(x => x.Title).HasColumnName("Title");
        _ = builder.Property<string>("_description").HasColumnName("Description");
        _ = builder.Property<MemberId>("_creatorId").HasColumnName("CreatorId").HasConversion(v => v.Value, c => new MemberId(c)); ;
        _ = builder.Property<MemberId>("_changeMemberId").HasColumnName("ChangeMemberId").HasConversion(v => v.Value, c => new MemberId(c)); ; ;
        _ = builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        _ = builder.Property<DateTime?>("_changeDate").HasColumnName("ChangeDate");
        _ = builder.Property<DateTime?>("_cancelDate").HasColumnName("CancelDate");
        _ = builder.Property<bool>("_isCanceled").HasColumnName("IsCanceled");
        _ = builder.Property<MemberId>("_cancelMemberId").HasColumnName("CancelMemberId").HasConversion(v => v.Value, c => new MemberId(c)); ; ;

        _ = builder.OwnsOne(x => x.Time, b =>
        {
            _ = b.Property(p => p.StartDate).HasColumnName("TermStartDate");
            _ = b.Property(p => p.EndDate).HasColumnName("TermEndDate");
        });

        _ = builder.OwnsOne<RsvpTime>("_rsvpTime", b =>
        {
            _ = b.Property(p => p.StartDate).HasColumnName("RSVPTermStartDate");
            _ = b.Property(p => p.EndDate).HasColumnName("RSVPTermEndDate");
        });

        _ = builder.OwnsOne<Money>("_eventFee", b =>
        {
            _ = b.Property(p => p.Value).HasColumnName("EventFeeValue");
            _ = b.Property(p => p.Currency).HasColumnName("EventFeeCurrency");
        });

        _ = builder.OwnsMany<EventParticipant>("_participants", y =>
        {
            _ = y.WithOwner().HasForeignKey("EventId");
            _ = y.ToTable("EventParticipants", "events");
            _ = y.Property<MemberId>("ParticipantId").HasConversion(v => v.Value, c => new MemberId(c));
            _ = y.Property<EventId>("EventId").HasConversion(v => v.Value, c => new EventId(c));
            _ = y.Property<DateTime>("_decisionDate").HasColumnName("DecisionDate");
            _ = y.HasKey("ParticipantId", "EventId", "_decisionDate");
            _ = y.Property<bool>("_decisionChanged").HasColumnName("DecisionChanged");
            _ = y.Property<DateTime?>("_decisionChangeDate").HasColumnName("DecisionChangeDate");
            _ = y.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
            _ = y.Property<string>("_removingReason").HasColumnName("RemovingReason");
            _ = y.Property<MemberId>("_removingMemberId").HasColumnName("RemovingMemberId").HasConversion(v => v.Value, c => new MemberId(c));
            _ = y.Property<DateTime?>("_removedDate").HasColumnName("RemovedDate");
            _ = y.Property<bool>("_isFeePaid").HasColumnName("IsFeePaid");

            _ = y.OwnsOne<EventParticipantRole>("_role", b =>
            {
                _ = b.Property(x => x.Value).HasColumnName("RoleCode");
            });

            _ = y.OwnsOne<Money>("_fee", b =>
            {
                _ = b.Property(p => p.Value).HasColumnName("FeeValue");
                _ = b.Property(p => p.Currency).HasColumnName("FeeCurrency");
            });
        });

        _ = builder.OwnsMany<EventWaiteListMember>("_waitlistMembers", y =>
       {
           _ = y.WithOwner().HasForeignKey("EventId");
           _ = y.ToTable("EventWaitlistMembers", "events");
           _ = y.Property<MemberId>("MemberId").HasConversion(v => v.Value, c => new MemberId(c));
           _ = y.Property<EventId>("EventId").HasConversion(v => v.Value, c => new EventId(c));
           _ = y.Property<DateTime>("SignUpDate").HasColumnName("SignUpDate");
           _ = y.HasKey("MemberId", "EventId", "SignUpDate");
           _ = y.Property<bool>("_isSignedOff").HasColumnName("IsSignedOff");
           _ = y.Property<DateTime?>("_signOffDate").HasColumnName("SignOffDate");

           _ = y.Property<bool>("_isMovedToParticipants").HasColumnName("IsMovedToParticipants");
           _ = y.Property<DateTime?>("_movedToParticipantsDate").HasColumnName("MovedToParticipantsDate");
       });

        _ = builder.OwnsOne<EventLimits>("_eventLimits", meetingLimits =>
        {
            _ = meetingLimits.Property(x => x.ParticipantsLimit).HasColumnName("ParticipantsLimit");
        });
    }
}
