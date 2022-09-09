using EventService.Application.Contracts.Commands;

namespace EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;

public class ChangeSubscriptionExpirationDateForMemberCommand : CommandBase
{
    public ChangeSubscriptionExpirationDateForMemberCommand(
        Guid id,
        Guid memberId,
        DateTime expirationDate)
        : base(id)
    {
        MemberId = memberId;
        ExpirationDate = expirationDate;
    }

    public Guid MemberId { get; }

    public DateTime ExpirationDate { get; }
}
