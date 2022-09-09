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
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<GetParticipantEventsInWhichTakesPartResponse>(
            "SELECT " +
            $"[EventParticipant].[Id] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.EventId)}], " +
            $"[EventParticipant].[RoleCode] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.RoleCode)}], " +
            $"[EventParticipant].[TermStartDate] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.TermStartDate)}], " +
            $"[EventParticipant].[TermEndDate] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.TermEndDate)}], " +
            $"[EventParticipant].[Title] AS [{nameof(GetParticipantEventsInWhichTakesPartResponse.Title)}] " +
            "FROM [events].[v_EventParticipants] AS [EventParticipant] " +
            "WHERE [Event].[ParticipantId] = @ParticipantId AND [Event].[IsRemoved] = 0",
            new
            {
                ParticipantId = _executionContextAccessor.UserId
            })).AsList(); //TODO: fix query 
    }
}