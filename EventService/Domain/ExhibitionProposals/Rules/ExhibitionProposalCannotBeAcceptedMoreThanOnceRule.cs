using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals.Rules;

public class ExhibitionProposalCannotBeAcceptedMoreThanOnceRule : IBaseBusinessRule
{
    private readonly ExhibitionProposalStatus _actualStatus;

    internal ExhibitionProposalCannotBeAcceptedMoreThanOnceRule(ExhibitionProposalStatus actualStatus)
    {
        _actualStatus = actualStatus;
    }

    public bool IsBroken() => _actualStatus.IsAccepted;

    public string Message => "Exhibition proposal cannot be accepted more than once";
}