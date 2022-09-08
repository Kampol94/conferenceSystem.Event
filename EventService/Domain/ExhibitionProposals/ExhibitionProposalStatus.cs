using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals;

public class ExhibitionProposalStatus : ValueObject
{
    public string Value { get; }

    internal static ExhibitionProposalStatus InVerification => new("InVerification");

    internal static ExhibitionProposalStatus Accepted => new("Accepted");

    internal bool IsAccepted => Value == "Accepted";

    private ExhibitionProposalStatus(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value; 
    }
}