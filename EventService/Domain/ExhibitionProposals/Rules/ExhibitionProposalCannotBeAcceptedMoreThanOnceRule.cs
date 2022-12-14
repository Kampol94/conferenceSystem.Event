using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals.Rules;

public class ExhibitionProposalCannotBeAcceptedMoreThanOnceRule : IBaseBusinessRule
{
    private readonly ExhibitionProposalStatus _actualStatus;

    public ExhibitionProposalCannotBeAcceptedMoreThanOnceRule(ExhibitionProposalStatus actualStatus)
    {
        _actualStatus = actualStatus;
    }

    public bool IsBroken()
    {
        return _actualStatus.IsAccepted;
    }

    public string Message => "Exhibition proposal cannot be accepted more than once";
}