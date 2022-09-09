using Dapper;
using EventService.Application.Contracts;
using EventService.Application.Contracts.Queries;

namespace EventService.Application.EventReviews.Queries.GetMeetingComments;

internal class GetEventReviewsQueryHandler : IQueryHandler<GetEventReviewsQuery, List<EventReviewsDto>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetEventReviewsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<List<EventReviewsDto>> Handle(GetEventReviewsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        string sql = "SELECT " +
                     $"[EventReviews].[Id] AS [{nameof(EventReviewsDto.Id)}], " +
                     $"[EventReviews].[InReplyToReviewId] AS [{nameof(EventReviewsDto.InReplyToReviewId)}], " +
                     $"[EventReviews].[AuthorId] AS [{nameof(EventReviewsDto.AuthorId)}], " +
                     $"[EventReviews].[Text] AS [{nameof(EventReviewsDto.Text)}], " +
                     $"[EventReviews].[CreateDate] AS [{nameof(EventReviewsDto.CreateDate)}], " +
                     $"[EventReviews].[EditDate] AS [{nameof(EventReviewsDto.EditDate)}], " +
                     "FROM [events].[v_EventReviews] AS [EventReviews] " +
                     "WHERE [EventReviews].[EventId] = @EventId";
        var eventReviews = await connection.QueryAsync<EventReviewsDto>(sql, new { query.EventId });

        return eventReviews.AsList();
    }
}