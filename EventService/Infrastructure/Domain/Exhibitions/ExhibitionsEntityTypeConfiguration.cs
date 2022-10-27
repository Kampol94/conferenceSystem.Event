using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.Exhibitions;

public class ExhibitionsEntityTypeConfiguration : IEntityTypeConfiguration<Exhibition>
{
    public void Configure(EntityTypeBuilder<Exhibition> builder)
    {
        _ = builder.ToTable("Exhibitions", "events");

        _ = builder.Property<ExhibitionId>("Id").HasConversion(v => v.Value, c => new ExhibitionId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property(x => x.Name).HasColumnName("Name");
        _ = builder.Property<string>("_description").HasColumnName("Description");
        _ = builder.Property(x => x.CreatorId).HasColumnName("CreatorId").HasConversion(v => v.Value, c => new MemberId(c));
        _ = builder.Property<DateTime>("_createDate").HasColumnName("CreateDate");
        _ = builder.Property<DateTime?>("_paymentDateTo").HasColumnName("PaymentDateTo");

        _ = builder.OwnsMany<ExhibitionMember>("_members", y =>
        {
            _ = y.WithOwner().HasForeignKey("ExhibitionId");
            _ = y.ToTable("ExhibitionMembers", "events");
            _ = y.Property<MemberId>("MemberId").HasConversion(v => v.Value, c => new MemberId(c));
            _ = y.Property<ExhibitionId>("ExhibitionId").HasConversion(v => v.Value, c => new ExhibitionId(c));
            _ = y.Property<DateTime>("JoinedDate").HasColumnName("JoinedDate");
            _ = y.HasKey("MemberId", "ExhibitionId", "JoinedDate");

            _ = y.Property<DateTime?>("_leaveDate").HasColumnName("LeaveDate");

            _ = y.Property<bool>("_isActive").HasColumnName("IsActive");

            _ = y.OwnsOne<ExhibitionMemberRole>("_role", b =>
            {
                _ = b.Property(x => x.Value).HasColumnName("RoleCode");
            });
        });
    }
}
