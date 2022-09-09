using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetEventDetails;

public class GetEventDetailsQueryHandler : IQueryHandler<GetEventDetailsQuery, GetEventDetailsResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEventDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<GetEventDetailsResponse> Handle(GetEventDetailsQuery query, CancellationToken cancellationToken)
    {
        System.Data.IDbConnection connection = _sqlConnectionFactory.GetOpenConnection();

        return await connection.QuerySingleAsync<GetEventDetailsResponse>(
            "SELECT " +
            $"[Events].[Id] AS [{nameof(GetEventDetailsResponse.Id)}], " +
            $"[Events].[ExhibitionId] AS [{nameof(GetEventDetailsResponse.ExhibitionId)}], " +
            $"[Events].[Title] AS [{nameof(GetEventDetailsResponse.Title)}], " +
            $"[Events].[TermStartDate] AS [{nameof(GetEventDetailsResponse.TermStartDate)}], " +
            $"[Events].[TermEndDate] AS [{nameof(GetEventDetailsResponse.TermEndDate)}], " +
            $"[Events].[Description] AS [{nameof(GetEventDetailsResponse.Description)}], " +
            $"[Events].[ParticipantsLimit] AS [{nameof(GetEventDetailsResponse.ParticipantsLimit)}], " +
            $"[Events].[RSVPTermStartDate] AS [{nameof(GetEventDetailsResponse.RSVPTermStartDate)}], " +
            $"[Events].[RSVPTermEndDate] AS [{nameof(GetEventDetailsResponse.RSVPTermEndDate)}], " +
            $"[Events].[EventFeeValue] AS [{nameof(GetEventDetailsResponse.EventFeeValue)}], " +
            $"[Events].[EventFeeCurrency] AS [{nameof(GetEventDetailsResponse.EventFeeCurrency)}] " +
            "FROM [events].[Events] AS [Events] " +
            "WHERE [Events].[Id] = @EventId",
            new
            {
                query.EventId
            });
    }
}