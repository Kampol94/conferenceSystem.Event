using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetParticipantEventsInWhichTakesPart;

public class GetParticipantEventsInWhichTakesPartQueryHandler : IQueryHandler<GetParticipantEventsInWhichTakesPartQuery, List<GetParticipantEventsInWhichTakesPartResponse>>
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

    public async Task<List<GetParticipantEventsInWhichTakesPartResponse>> Handle(GetParticipantEventsInWhichTakesPartQuery request, CancellationToken cancellationToken)
    {
        System.Data.IDbConnection connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<GetParticipantEventsInWhichTakesPartResponse>(
            "SELECT " +
            $"[ParticipantEvent].[Id] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.EventId)}], " +
            $"[ParticipantEvent].[RoleCode] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.RoleCode)}], " +
            $"[ParticipantEvent].[TermStartDate] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.TermStartDate)}], " +
            $"[ParticipantEvent].[TermEndDate] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.TermEndDate)}], " +
            $"[ParticipantEvent].[Title] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.Title)}] " +
            "FROM [events].[v_ParticipantEvents] AS [ParticipantEvent] " +
            "WHERE [ParticipantEvent].[ParticipantId] = @ParticipantId AND [ParticipantEvent].[IsRemoved] = 0",
            new
            {
                ParticipantId = _executionContextAccessor.UserId
            })).AsList();
    }
}