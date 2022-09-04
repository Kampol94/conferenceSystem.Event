using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Comments;

namespace EventService.Domain.EventReviews;

public interface IMeetingCommentRepository
{
    Task AddAsync(MeetingComment meetingComment);

    Task<MeetingComment> GetByIdAsync(MeetingCommentId meetingCommentId);
}