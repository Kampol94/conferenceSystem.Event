using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.ExhibitionProposals;

public class ExhibitionProposalEntityTypeConfiguration : IEntityTypeConfiguration<ExhibitionProposal>
{
    public void Configure(EntityTypeBuilder<ExhibitionProposal> builder)
    {
        _ = builder.ToTable("ExhibitionProposals", "events");

        _ = builder.Property<ExhibitionProposalId>("Id").HasConversion(v => v.Value, c => new ExhibitionProposalId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property<string>("_name").HasColumnName("Name");
        _ = builder.Property<string>("_description").HasColumnName("Description");
        _ = builder.Property<MemberId>("_proposalUserId").HasColumnName("ProposalUserId").HasConversion(v => v.Value, c => new MemberId(c));
        _ = builder.Property<DateTime>("_proposalDate").HasColumnName("ProposalDate");

        _ = builder.OwnsOne<ExhibitionProposalStatus>("_status", b =>
        {
            _ = b.Property(p => p.Value).HasColumnName("StatusCode");
        });
    }
}
