using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetParticipantEventsInWhichTakesPart;

internal class GetParticipantEventsInWhichTakesPartQueryHandler : IQueryHandler<GetParticipantEventsInWhichTakesPartQuery, List<GetParticipantEventsInWhichTakesPartRespone>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    private readonly IExecutionContextAccessor _executionContextAccessor;

    public GetParticipantEventsInWhichTakesPartQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IExecutionContextAccessor executionContextAccessor)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _executionContextAccessor = executionContextAccessor;
    }

    public async Task<List<GetParticipantEventsInWhichTakesPartRespone>> Handle(GetParticipantEventsInWhichTakesPartQuery request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<GetParticipantEventsInWhichTakesPartRespone>(
            "SELECT " +
            $"[Event].[Id] AS [{nameof(GetParticipantEventsInWhichTakesPartRespone.EventId)}], " +
            $"[Event].[RoleCode] AS [{nameof(GetParticipantEventsInWhichTakesPartRespone.RoleCode)}], " +
            $"[Event].[TermStartDate] AS [{nameof(GetParticipantEventsInWhichTakesPartRespone.TermStartDate)}], " +
            $"[Event].[TermEndDate] AS [{nameof(GetParticipantEventsInWhichTakesPartRespone.TermEndDate)}], " +
            $"[Event].[Title] AS [{nameof(GetParticipantEventsInWhichTakesPartRespone.Title)}] " +
            "FROM [events].[v_MemberEvents] AS [Event] " +
            "WHERE [Event].[ParticipantId] = @ParticipantId AND [Event].[IsRemoved] = 0",
            new
            {
                ParticipantId = _executionContextAccessor.UserId
            })).AsList();
    }
}