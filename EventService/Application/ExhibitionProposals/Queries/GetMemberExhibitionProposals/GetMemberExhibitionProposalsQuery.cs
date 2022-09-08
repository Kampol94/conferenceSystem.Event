using EventService.Application.Contracts.Queries;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;

namespace EventService.Application.ExhibitionProposals.Queries.GetMemberExhibitionProposals;

public class GetMemberExhibitionProposalsQuery : QueryBase<List<ExhibitionProposalDto>>
{
    public GetMemberExhibitionProposalsQuery()
    {
    }
}