using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.ExhibitionProposals;

public class ExhibitionProposalEntityTypeConfiguration : IEntityTypeConfiguration<ExhibitionProposal>
{
    public void Configure(EntityTypeBuilder<ExhibitionProposal> builder)
    {
        builder.ToTable("ExhibitionProposals", "events");

        builder.Property<ExhibitionProposalId>("Id").HasConversion(v => v.Value, c => new ExhibitionProposalId(c));
        builder.HasKey("Id");

        builder.Property<string>("_name").HasColumnName("Name");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property<MemberId>("_proposalUserId").HasColumnName("ProposalUserId").HasConversion(v => v.Value, c => new MemberId(c));
        builder.Property<DateTime>("_proposalDate").HasColumnName("ProposalDate");

        builder.OwnsOne<ExhibitionProposalStatus>("_status", b =>
        {
            b.Property(p => p.Value).HasColumnName("StatusCode");
        });
    }
}
