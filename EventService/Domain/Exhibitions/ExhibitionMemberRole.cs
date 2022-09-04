using EventService.Domain.Contracts;

namespace EventService.Domain.Exhibitions;

public class ExhibitionMemberRole : ValueObject
{
    public static ExhibitionMemberRole Organizer => new ExhibitionMemberRole("Organizer");

    public static ExhibitionMemberRole Member => new ExhibitionMemberRole("Member");

    public string Value { get; }

    private ExhibitionMemberRole(string value)
    {
        Value = value;
    }

    public static ExhibitionMemberRole Of(string roleCode)
    {
        return new ExhibitionMemberRole(roleCode);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}