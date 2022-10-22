using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibitions.Queries.GetAuthenticationMemberExhibition;

public class GetAuthenticationMemberExhibitionsQueryHandler :
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
        System.Data.IDbConnection connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                  $"[ExhibitionMember].[Id] AS [{nameof(MemberExhibitionDto.Id)}], " +
                  $"[ExhibitionMember].[Name] AS [{nameof(MemberExhibitionDto.Name)}], " +
                  $"[ExhibitionMember].[Description] AS [{nameof(MemberExhibitionDto.Description)}], " +
                  $"[ExhibitionMember].[MemberId] AS [{nameof(MemberExhibitionDto.MemberId)}], " +
                  $"[ExhibitionMember].[RoleCode] AS [{nameof(MemberExhibitionDto.RoleCode)}] " +
                  "FROM [events].[v_ExhibitionMembers] AS [ExhibitionMember] " +
                  "WHERE [ExhibitionMember].MemberId = @MemberId AND [ExhibitionMember].[IsActive] = 1";

        IEnumerable<MemberExhibitionDto> exhibitions = await connection.QueryAsync<MemberExhibitionDto>(
            sql,
            new
            {
                MemberId = _executionContextAccessor.UserId
            });

        return exhibitions.AsList();
    }
}