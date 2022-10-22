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
        builder.ToTable("Events", "events");

        builder.Property<EventId>("Id").HasConversion(v => v.Value, c => new EventId(c));
        builder.HasKey("Id");

        builder.Property<ExhibitionId>("_exhibitionId").HasColumnName("ExhibitionId").HasConversion(v => v.Value, c => new ExhibitionId(c)); ;
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<MemberId>("_creatorId").HasColumnName("CreatorId").HasConversion(v => v.Value, c => new MemberId(c)); ;
        builder.Property<MemberId>("_changeMemberId").HasColumnName("ChangeMemberId").HasConversion(v => v.Value, c => new MemberId(c)); ; ;
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime?>("_changeDate").HasColumnName("ChangeDate");
        builder.Property<DateTime?>("_cancelDate").HasColumnName("CancelDate");
        builder.Property<bool>("_isCanceled").HasColumnName("IsCanceled");
        builder.Property<MemberId>("_cancelMemberId").HasColumnName("CancelMemberId").HasConversion(v => v.Value, c => new MemberId(c)); ; ;

        builder.OwnsOne(x => x.Time, b =>
        {
            b.Property(p => p.StartDate).HasColumnName("TermStartDate");
            b.Property(p => p.EndDate).HasColumnName("TermEndDate");
        });

        builder.OwnsOne<RsvpTime>("_rsvpTime", b =>
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
            y.Property<MemberId>("ParticipantId").HasConversion(v => v.Value, c => new MemberId(c));
            y.Property<EventId>("EventId").HasConversion(v => v.Value, c => new EventId(c));
            y.Property<DateTime>("_decisionDate").HasColumnName("DecisionDate");
            y.HasKey("ParticipantId", "EventId", "_decisionDate");
            y.Property<bool>("_decisionChanged").HasColumnName("DecisionChanged");
            y.Property<DateTime?>("_decisionChangeDate").HasColumnName("DecisionChangeDate");
            y.Property<bool>("_isRemoved").HasColumnName("IsRemoved");
            y.Property<string>("_removingReason").HasColumnName("RemovingReason");
            y.Property<MemberId>("_removingMemberId").HasColumnName("RemovingMemberId").HasConversion(v => v.Value, c => new MemberId(c));
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

        builder.OwnsMany<EventWaiteListMember>("_waitlistMembers", y =>
       {
           y.WithOwner().HasForeignKey("EventId");
           y.ToTable("EventWaitlistMembers", "events");
           y.Property<MemberId>("MemberId").HasConversion(v => v.Value, c => new MemberId(c));
           y.Property<EventId>("EventId").HasConversion(v => v.Value, c => new EventId(c));
           y.Property<DateTime>("SignUpDate").HasColumnName("SignUpDate");
           y.HasKey("MemberId", "EventId", "SignUpDate");
           y.Property<bool>("_isSignedOff").HasColumnName("IsSignedOff");
           y.Property<DateTime?>("_signOffDate").HasColumnName("SignOffDate");

           y.Property<bool>("_isMovedToParticipants").HasColumnName("IsMovedToParticipants");
           y.Property<DateTime?>("_movedToParticipantsDate").HasColumnName("MovedToParticipantsDate");
       });

        builder.OwnsOne<EventLimits>("_eventLimits", meetingLimits =>
        {
            meetingLimits.Property(x => x.ParticipantsLimit).HasColumnName("ParticipantsLimit");
        });
    }
}
