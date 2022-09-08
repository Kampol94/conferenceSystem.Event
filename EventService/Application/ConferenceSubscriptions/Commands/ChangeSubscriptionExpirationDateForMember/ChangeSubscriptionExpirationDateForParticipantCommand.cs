using EventService.Application.Contracts.Commands;
using EventService.Domain.Members;

namespace EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;

public class ChangeSubscriptionExpirationDateForMemberCommand : CommandBase
{
    public ChangeSubscriptionExpirationDateForMemberCommand(
        Guid id,
        MemberId memberId,
        DateTime expirationDate)
        : base(id)
    {
        MemberId = memberId;
        ExpirationDate = expirationDate;
    }

    public MemberId MemberId { get; }

    public DateTime ExpirationDate { get; }
}
