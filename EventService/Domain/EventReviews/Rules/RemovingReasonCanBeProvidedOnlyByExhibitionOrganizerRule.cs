using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class RemovingReasonCanBeProvidedOnlyByExhibitionOrganizerRule : IBaseBusinessRule
{
    private readonly Exhibition _exhibition;
    private readonly MemberId _removingMemberId;
    private readonly string _removingReason;

    public RemovingReasonCanBeProvidedOnlyByExhibitionOrganizerRule(Exhibition exhibition, MemberId removingMemberId, string removingReason)
    {
        _exhibition = exhibition;
        _removingMemberId = removingMemberId;
        _removingReason = removingReason;
    }

    public bool IsBroken()
    {
        return !string.IsNullOrEmpty(_removingReason) && !_exhibition.IsOrganizer(_removingMemberId);
    }

    public string Message => "Only exhibition organizer can provide review's removing reason.";
}