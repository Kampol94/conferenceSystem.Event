using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals;

public class ExhibitionProposalStatus : ValueObject
{
    public string Value { get; }

    public static ExhibitionProposalStatus InVerification => new("InVerification");

    public static ExhibitionProposalStatus Accepted => new("Accepted");

    public bool IsAccepted => Value == "Accepted";

    private ExhibitionProposalStatus(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}