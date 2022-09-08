using EventService.Application.Contracts.Queries;

namespace EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;

public class GetExhibitionProposalQuery : QueryBase<ExhibitionProposalDto>
{
    public GetExhibitionProposalQuery(Guid exhibitionProposalId)
    {
        ExhibitionProposalId = exhibitionProposalId;
    }

    public Guid ExhibitionProposalId { get; }
}