using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;
using EventService.Application.ExhibitionProposals.Queries.GetExhibitionProposal;

namespace EventService.Application.ExhibitionProposals.Queries.GetAllExhibitionProposals;

internal class GetAllExhibitionProposalsQueryHandler : IQueryHandler<GetAllExhibitionProposalsQuery, List<ExhibitionProposalDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllExhibitionProposalsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionProposalDto>> Handle(GetAllExhibitionProposalsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[ExhibitionProposal].[Id] AS [{nameof(ExhibitionProposalDto.Id)}], " +
                     $"[ExhibitionProposal].[Name] AS [{nameof(ExhibitionProposalDto.Name)}], " +
                     $"[ExhibitionProposal].[ProposalUserId] AS [{nameof(ExhibitionProposalDto.ProposalUserId)}], " +
                     $"[ExhibitionProposal].[LocationCity] AS [{nameof(ExhibitionProposalDto.LocationCity)}], " +
                     $"[ExhibitionProposal].[LocationCountryCode] AS [{nameof(ExhibitionProposalDto.LocationCountryCode)}], " +
                     $"[ExhibitionProposal].[Description] AS [{nameof(ExhibitionProposalDto.Description)}], " +
                     $"[ExhibitionProposal].[ProposalDate] AS [{nameof(ExhibitionProposalDto.ProposalDate)}], " +
                     $"[ExhibitionProposal].[StatusCode] AS [{nameof(ExhibitionProposalDto.StatusCode)}] " +
                     "FROM [meetings].[v_ExhibitionProposals] AS [ExhibitionProposal] " +
                     "ORDER BY [ExhibitionProposal].[Name]";

        var exhibitionProposals = await connection.QueryAsync<ExhibitionProposalDto>(sql);

        return exhibitionProposals.AsList();
    }
}