using CompanyName.MyEvents.Modules.Events.Application.Events.GetEventParticipants;
using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.GetEventParticipants;

internal class GetEventParticipantsQueryHandler : IQueryHandler<GetEventParticipantsQuery, List<GetEventParticipantsRespone>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEventParticipantsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<GetEventParticipantsRespone>> Handle(GetEventParticipantsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return (await connection.QueryAsync<GetEventParticipantsRespone>(
            "SELECT " +
            $"[EventParticipant].[FirstName] AS [{nameof(GetEventParticipantsRespone.FirstName)}], " +
            $"[EventParticipant].[LastName] AS [{nameof(GetEventParticipantsRespone.LastName)}], " +
            $"[EventParticipant].[RoleCode] AS [{nameof(GetEventParticipantsRespone.RoleCode)}], " +
            $"[EventParticipant].[DecisionDate] AS [{nameof(GetEventParticipantsRespone.DecisionDate)}], " +
            $"[EventParticipant].[ParticipantId] AS [{nameof(GetEventParticipantsRespone.ParticipantId)}] " +
            "FROM [events].[v_EventParticipants] AS [EventParticipant] " +
            "WHERE [EventParticipant].[EventId] = @EventId",
            new
            {
                query.EventId
            })).AsList();
    }
}