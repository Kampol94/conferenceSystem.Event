using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Domain.Members;

public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        _ = builder.ToTable("Members", "events");

        _ = builder.Property<MemberId>("Id").HasConversion(v => v.Value, c => new MemberId(c));
        _ = builder.HasKey("Id");

        _ = builder.Property<string>("_login").HasColumnName("Login");
        _ = builder.Property<string>("_email").HasColumnName("Email");
        _ = builder.Property<string>("_firstName").HasColumnName("FirstName");
        _ = builder.Property<string>("_lastName").HasColumnName("LastName");
        _ = builder.Property<string>("_name").HasColumnName("Name");
    }
}
