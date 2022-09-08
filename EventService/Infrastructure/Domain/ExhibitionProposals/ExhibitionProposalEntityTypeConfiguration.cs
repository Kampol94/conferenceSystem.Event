﻿using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.MeetingGroupProposals;

internal class ExhibitionProposalEntityTypeConfiguration : IEntityTypeConfiguration<ExhibitionProposal>
{
    public void Configure(EntityTypeBuilder<ExhibitionProposal> builder)
    {
        builder.ToTable("ExhibitionProposals", "events");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property<string>("_name").HasColumnName("Name");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<MemberId>("_proposalUserId").HasColumnName("ProposalUserId");
        builder.Property<DateTime>("_proposalDate").HasColumnName("ProposalDate");

        builder.OwnsOne<ExhibitionProposalStatus>("_status", b =>
        {
            b.Property(p => p.Value).HasColumnName("StatusCode");
        });
    }
}
