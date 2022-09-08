using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.BuildingBlocks.Application;
using CompanyName.MyMeetings.BuildingBlocks.Application.Data;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Queries;
using CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetAllExhibitions;
using Dapper;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetAuthenticationMemberExhibitions;

internal class GetAuthenticationMemberExhibitionsQueryHandler :
    IQueryHandler<GetAuthenticationMemberExhibitionsQuery, List<MemberExhibitionDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    private readonly IExecutionContextAccessor _executionContextAccessor;

    public GetAuthenticationMemberExhibitionsQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IExecutionContextAccessor executionContextAccessor)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _executionContextAccessor = executionContextAccessor;
    }

    public async Task<List<MemberExhibitionDto>> Handle(
        GetAuthenticationMemberExhibitionsQuery query,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        var sql = "SELECT " +
                  $"[MemberExhibition].[Id] AS [{nameof(MemberExhibitionDto.Id)}], " +
                  $"[MemberExhibition].[Name] AS [{nameof(MemberExhibitionDto.Name)}], " +
                  $"[MemberExhibition].[Description] AS [{nameof(MemberExhibitionDto.Description)}], " +
                  $"[MemberExhibition].[LocationCountryCode] AS [{nameof(MemberExhibitionDto.LocationCountryCode)}], " +
                  $"[MemberExhibition].[LocationCity] AS [{nameof(MemberExhibitionDto.LocationCity)}], " +
                  $"[MemberExhibition].[MemberId] AS [{nameof(MemberExhibitionDto.MemberId)}], " +
                  $"[MemberExhibition].[RoleCode] AS [{nameof(MemberExhibitionDto.RoleCode)}] " +
                  "FROM [meetings].[v_MemberExhibitions] AS [MemberExhibition] " +
                  "WHERE [MemberExhibition].MemberId = @MemberId AND [MemberExhibition].[IsActive] = 1";

        var Exhibitions = await connection.QueryAsync<MemberExhibitionDto>(
            sql,
            new
            {
                MemberId = _executionContextAccessor.UserId
            });

        return Exhibitions.AsList();
    }
}