using EventService.Domain.Contracts;

namespace EventService.Domain.ExhibitionProposals;

public class ExhibitionProposalId : IdValueBase
{
    public ExhibitionProposalId(Guid value) : base(value)
    {
    }
}