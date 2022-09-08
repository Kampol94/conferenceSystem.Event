using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibition.Queries.GetAuthenticationMemberMeetingGroups;

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

        var exhibitions = await connection.QueryAsync<MemberExhibitionDto>(
            sql,
            new
            {
                MemberId = _executionContextAccessor.UserId
            });

        return exhibitions.AsList();
    }
}