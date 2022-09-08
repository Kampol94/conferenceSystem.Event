using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.BuildingBlocks.Application.Data;
using CompanyName.MyMeetings.BuildingBlocks.Infrastructure;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Queries;
using Dapper;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetAllExhibitions;

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
                           "[Exhibition].[LocationCountryCode], " +
                           "[Exhibition].[LocationCity]" +
                           "FROM [meetings].[v_Exhibitions] AS [Exhibition]";
        var Exhibitions = await connection.QueryAsync<ExhibitionDto>(sql);

        return Exhibitions.AsList();
    }
}