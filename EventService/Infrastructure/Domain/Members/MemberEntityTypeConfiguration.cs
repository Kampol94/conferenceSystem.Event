using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.Members;

public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Members", "events");

        builder.Property<MemberId>("Id").HasConversion(v => v.Value, c => new MemberId(c));
        builder.HasKey("Id");

        builder.Property<string>("_login").HasColumnName("Login");
        builder.Property<string>("_email").HasColumnName("Email");
        builder.Property<string>("_firstName").HasColumnName("FirstName");
        builder.Property<string>("_lastName").HasColumnName("LastName");
        builder.Property<string>("_name").HasColumnName("Name");
    }
}
