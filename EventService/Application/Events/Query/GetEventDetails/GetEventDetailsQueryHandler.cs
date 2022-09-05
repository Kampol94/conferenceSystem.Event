using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetEventDetails;

internal class GetEventDetailsQueryHandler : IQueryHandler<GetEventDetailsQuery, GetEventDetailsRespone>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEventDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetEventDetailsRespone> Handle(GetEventDetailsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return await connection.QuerySingleAsync<GetEventDetailsRespone>(
            "SELECT " +
            $"[EventDetails].[Id] AS [{nameof(GetEventDetailsRespone.Id)}], " +
            $"[EventDetails].[ExhibitionId] AS [{nameof(GetEventDetailsRespone.ExhibitionId)}], " +
            $"[EventDetails].[Title] AS [{nameof(GetEventDetailsRespone.Title)}], " +
            $"[EventDetails].[TermStartDate] AS [{nameof(GetEventDetailsRespone.TermStartDate)}], " +
            $"[EventDetails].[TermEndDate] AS [{nameof(GetEventDetailsRespone.TermEndDate)}], " +
            $"[EventDetails].[Description] AS [{nameof(GetEventDetailsRespone.Description)}], " +
            $"[EventDetails].[ParticipantsLimit] AS [{nameof(GetEventDetailsRespone.ParticipantsLimit)}], " +
            $"[EventDetails].[RSVPTermStartDate] AS [{nameof(GetEventDetailsRespone.RSVPTermStartDate)}], " +
            $"[EventDetails].[RSVPTermEndDate] AS [{nameof(GetEventDetailsRespone.RSVPTermEndDate)}], " +
            $"[EventDetails].[EventFeeValue] AS [{nameof(GetEventDetailsRespone.EventFeeValue)}], " +
            $"[EventDetails].[EventFeeCurrency] AS [{nameof(GetEventDetailsRespone.EventFeeCurrency)}] " +
            "FROM [events].[v_EventDetails] AS [EventDetails] " +
            "WHERE [EventDetails].[Id] = @EventId",
            new
            {
                query.EventId
            });
    }
}