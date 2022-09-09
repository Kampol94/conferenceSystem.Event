using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;
using EventService.Domain.Members;

namespace EventService.Application.ExhibitionProposals.Queries.GetMemberExhibitionProposals;

public class GetMemberExhibitionProposalsQueryHandler : IQueryHandler<GetMemberExhibitionProposalsQuery, List<ExhibitionProposalDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    private readonly IMemberContext _memberContext;

    public GetMemberExhibitionProposalsQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IMemberContext memberContext)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _memberContext = memberContext;
    }

    public async Task<List<ExhibitionProposalDto>> Handle(GetMemberExhibitionProposalsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[ExhibitionProposal].[Id] AS [{nameof(ExhibitionProposalDto.Id)}], " +
                     $"[ExhibitionProposal].[Name] AS [{nameof(ExhibitionProposalDto.Name)}], " +
                     $"[ExhibitionProposal].[ProposalUserId] AS [{nameof(ExhibitionProposalDto.ProposalUserId)}], " +
                     $"[ExhibitionProposal].[Description] AS [{nameof(ExhibitionProposalDto.Description)}], " +
                     $"[ExhibitionProposal].[ProposalDate] AS [{nameof(ExhibitionProposalDto.ProposalDate)}], " +
                     $"[ExhibitionProposal].[StatusCode] AS [{nameof(ExhibitionProposalDto.StatusCode)}] " +
                     "FROM [events].[v_ExhibitionProposals] AS [ExhibitionProposal] " +
                     "WHERE [ExhibitionProposal].ProposalUserId = @MemberId " +
                     "ORDER BY [ExhibitionProposal].[Name]";

        var exhibitionProposals = await connection.QueryAsync<ExhibitionProposalDto>(
            sql,
            new
            {
                MemberId = _memberContext.MemberId.Value
            });

        return exhibitionProposals.AsList();
    }
}