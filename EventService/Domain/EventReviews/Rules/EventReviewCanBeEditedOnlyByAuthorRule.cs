using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class EventReviewCanBeEditedOnlyByAuthorRule : IBaseBusinessRule
{
    private readonly MemberId _authorId;
    private readonly MemberId _editorId;

    public EventReviewCanBeEditedOnlyByAuthorRule(MemberId authorId, MemberId editorId)
    {
        _authorId = authorId;
        _editorId = editorId;
    }

    public bool IsBroken()
    {
        return _editorId != _authorId;
    }

    public string Message => "Only the author of a review can edit it.";
}