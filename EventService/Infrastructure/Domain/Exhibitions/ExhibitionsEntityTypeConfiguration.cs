using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.Exhibitions;

public class ExhibitionsEntityTypeConfiguration : IEntityTypeConfiguration<Exhibition>
{
    public void Configure(EntityTypeBuilder<Exhibition> builder)
    {
        builder.ToTable("Exhibitions", "events");

        builder.Property<ExhibitionId>("Id").HasConversion(v => v.Value, c => new ExhibitionId(c));
        builder.HasKey("Id");

        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property<string>("_description").HasColumnName("Description");
        builder.Property(x => x.CreatorId).HasColumnName("CreatorId").HasConversion(v => v.Value, c => new MemberId(c));
        builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        builder.Property<DateTime?>("_paymentDateTo").HasColumnName("PaymentDateTo");

        builder.OwnsMany<ExhibitionMember>("_members", y =>
        {
            y.WithOwner().HasForeignKey("ExhibitionId");
            y.ToTable("ExhibitionMembers", "events");
            y.Property<MemberId>("MemberId").HasConversion(v => v.Value, c => new MemberId(c));
            y.Property<ExhibitionId>("ExhibitionId").HasConversion(v => v.Value, c => new ExhibitionId(c));
            y.Property<DateTime>("JoinedDate").HasColumnName("JoinedDate");
            y.HasKey("MemberId", "ExhibitionId", "JoinedDate");

            y.Property<DateTime?>("_leaveDate").HasColumnName("LeaveDate");

            y.Property<bool>("_isActive").HasColumnName("IsActive");

            y.OwnsOne<ExhibitionMemberRole>("_role", b =>
            {
                b.Property(x => x.Value).HasColumnName("RoleCode");
            });
        });
    }
}
