using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetEventParticipants;

internal class GetEventParticipantsQueryHandler : IQueryHandler<GetEventParticipantsQuery, List<GetEventParticipantsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEventParticipantsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<GetEventParticipantsResponse>> Handle(GetEventParticipantsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<GetEventParticipantsResponse>(
            "SELECT " +
            $"[EventParticipant].[FirstName] AS [{nameof(GetEventParticipantsResponse.FirstName)}], " +
            $"[EventParticipant].[LastName] AS [{nameof(GetEventParticipantsResponse.LastName)}], " +
            $"[EventParticipant].[RoleCode] AS [{nameof(GetEventParticipantsResponse.RoleCode)}], " +
            $"[EventParticipant].[DecisionDate] AS [{nameof(GetEventParticipantsResponse.DecisionDate)}], " +
            $"[EventParticipant].[ParticipantId] AS [{nameof(GetEventParticipantsResponse.ParticipantId)}] " +
            "FROM [events].[v_EventParticipants] AS [EventParticipant] " +
            "WHERE [EventParticipant].[EventId] = @EventId",
            new
            {
                query.EventId
            })).AsList();
    }
}