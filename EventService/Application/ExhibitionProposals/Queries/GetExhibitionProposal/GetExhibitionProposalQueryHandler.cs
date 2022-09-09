using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;

public class GetExhibitionProposalQueryHandler : IQueryHandler<GetExhibitionProposalQuery, ExhibitionProposalDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetExhibitionProposalQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ExhibitionProposalDto> Handle(GetExhibitionProposalQuery query, CancellationToken cancellationToken)
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
                     "WHERE [ExhibitionProposal].[Id] = @ExhibitionProposalId";

        return await connection.QuerySingleAsync<ExhibitionProposalDto>(sql, new { query.ExhibitionProposalId });
    }
}