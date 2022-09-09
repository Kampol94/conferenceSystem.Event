using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibition.Queries.GetAllExhibitions;

internal class GetAllExhibitionsQueryHandler : IQueryHandler<GetAllExhibitionsQuery, List<ExhibitionDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    internal GetAllExhibitionsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionDto>> Handle(GetAllExhibitionsQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = "SELECT " +
                           "[Exhibition].[Id], " +
                           "[Exhibition].[Name], " +
                           "[Exhibition].[Description], " +
                           "FROM [events].[v_Exhibitions] AS [Exhibition]";
        var exhibitions = await connection.QueryAsync<ExhibitionDto>(sql);

        return exhibitions.AsList();
    }
}