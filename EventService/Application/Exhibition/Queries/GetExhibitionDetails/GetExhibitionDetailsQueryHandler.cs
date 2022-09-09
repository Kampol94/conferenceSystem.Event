using System.Data;
using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibition.Queries.GetExhibitionDetails;

internal class GetExhibitionDetailsQueryHandler : IQueryHandler<GetExhibitionDetailsQuery, ExhibitionDetailsDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetExhibitionDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ExhibitionDetailsDto> Handle(GetExhibitionDetailsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.GetOpenConnection();

        var exhibitionDetail = await connection.QuerySingleAsync<ExhibitionDetailsDto>(
            "SELECT " +
            $"[Exhibition].[Id] AS [{nameof(ExhibitionDetailsDto.Id)}], " +
            $"[Exhibition].[Name] AS [{nameof(ExhibitionDetailsDto.Name)}], " +
            $"[Exhibition].[Description] AS [{nameof(ExhibitionDetailsDto.Description)}], " +
            "FROM [events].[v_Exhibitions] AS [Exhibition] " +
            "WHERE [Exhibition].[Id] = @ExhibitionId",
            new
            {
                query.ExhibitionId
            });

        exhibitionDetail.MembersCount = await GetMembersCount(query.ExhibitionId, connection);

        return exhibitionDetail;
    }

    private static async Task<int> GetMembersCount(Guid ExhibitionId, IDbConnection connection)
    {
        return await connection.ExecuteScalarAsync<int>(
            "SELECT " +
            "COUNT(*) " +
            "FROM [events].[v_ExhibitionMembers] AS [ExhibitionMembers] " +
            "WHERE [ExhibitionMembers].[ExhibitionId] = @ExhibitionId AND " +
            "[ExhibitionMembers].[IsActive] = 1",
            new
            {
                ExhibitionId
            });
    }
}