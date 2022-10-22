using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;

namespace EventService.Application.ExhibitionProposals.Queries.GetAllExhibitionProposals;

public class GetAllExhibitionProposalsQueryHandler : IQueryHandler<GetAllExhibitionProposalsQuery, List<ExhibitionProposalDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllExhibitionProposalsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionProposalDto>> Handle(GetAllExhibitionProposalsQuery query, CancellationToken cancellationToken)
    {
        System.Data.IDbConnection connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[ExhibitionProposal].[Id] AS [{nameof(ExhibitionProposalDto.Id)}], " +
                     $"[ExhibitionProposal].[Name] AS [{nameof(ExhibitionProposalDto.Name)}], " +
                     $"[ExhibitionProposal].[ProposalUserId] AS [{nameof(ExhibitionProposalDto.ProposalUserId)}], " +
                     $"[ExhibitionProposal].[Description] AS [{nameof(ExhibitionProposalDto.Description)}], " +
                     $"[ExhibitionProposal].[ProposalDate] AS [{nameof(ExhibitionProposalDto.ProposalDate)}], " +
                     $"[ExhibitionProposal].[StatusCode] AS [{nameof(ExhibitionProposalDto.StatusCode)}] " +
                     "FROM [events].[ExhibitionProposals] AS [ExhibitionProposal] " +
                     "ORDER BY [ExhibitionProposal].[Name]";

        IEnumerable<ExhibitionProposalDto> exhibitionProposals = await connection.QueryAsync<ExhibitionProposalDto>(sql);

        return exhibitionProposals.AsList();
    }
}