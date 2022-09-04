using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class ReviewCanBeAddedOnlyByExhibitionMemberRule : IBaseBusinessRule
{
    private readonly MemberId _authorId;
    private readonly Exhibition _exhibition;

    public ReviewCanBeAddedOnlyByExhibitionMemberRule(MemberId authorId, Exhibition exhibition)
    {
        _authorId = authorId;
        _exhibition = exhibition;
    }

    public bool IsBroken() => !_exhibition.IsMemberOfGroup(_authorId);

    public string Message => "Only event participants can add review";
}