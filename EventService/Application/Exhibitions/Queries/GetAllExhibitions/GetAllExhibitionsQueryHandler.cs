using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibitions.Queries.GetAllExhibitions;

public class GetAllExhibitionsQueryHandler : IQueryHandler<GetAllExhibitionsQuery, List<ExhibitionDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetAllExhibitionsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<ExhibitionDto>> Handle(GetAllExhibitionsQuery request, CancellationToken cancellationToken)
    {
        System.Data.IDbConnection connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = "SELECT " +
                           "[Exhibition].[Id], " +
                           "[Exhibition].[Name], " +
                           "[Exhibition].[Description], " +
                           "FROM [events].[v_Exhibitions] AS [Exhibition]";
        IEnumerable<ExhibitionDto> exhibitions = await connection.QueryAsync<ExhibitionDto>(sql);

        return exhibitions.AsList();
    }
}