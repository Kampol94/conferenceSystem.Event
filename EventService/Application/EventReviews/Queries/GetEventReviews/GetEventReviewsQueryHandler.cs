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
                     $"[EventReviews].[InReplyToCommentId] AS [{nameof(EventReviewsDto.InReplyToCommentId)}], " +
                     $"[EventReviews].[AuthorId] AS [{nameof(EventReviewsDto.AuthorId)}], " +
                     $"[EventReviews].[Comment] AS [{nameof(EventReviewsDto.Comment)}], " +
                     $"[EventReviews].[CreateDate] AS [{nameof(EventReviewsDto.CreateDate)}], " +
                     $"[EventReviews].[EditDate] AS [{nameof(EventReviewsDto.EditDate)}], " +
                     $"[EventReviews].[LikesCount] AS [{nameof(EventReviewsDto.LikesCount)}]" +
                     "FROM [meetings].[v_EventReviewss] AS [EventReviews] " +
                     "WHERE [EventReviews].[MeetingId] = @MeetingId";
        var eventReviewss = await connection.QueryAsync<EventReviewsDto>(sql, new { query.EventId });

        return eventReviewss.AsList();
    }
}