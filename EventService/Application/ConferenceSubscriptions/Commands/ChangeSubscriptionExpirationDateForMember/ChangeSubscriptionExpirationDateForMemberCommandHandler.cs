using EventService.Application.Contracts.Commands;
using EventService.Domain.ConferenceSubscriptions;
using MediatR;

namespace EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;

public class ChangeSubscriptionExpirationDateForMemberCommandHandler : ICommandHandler<ChangeSubscriptionExpirationDateForMemberCommand>
{
    private readonly IConferenceSubscriptionRepository _conferenceSubscriptionRepository;

    public ChangeSubscriptionExpirationDateForMemberCommandHandler(IConferenceSubscriptionRepository conferenceSubscriptionRepository)
    {
        _conferenceSubscriptionRepository = conferenceSubscriptionRepository;
    }

    public async Task<Unit> Handle(ChangeSubscriptionExpirationDateForMemberCommand command, CancellationToken cancellationToken)
    {
        ConferenceSubscription conferenceSubscription = await _conferenceSubscriptionRepository.GetByIdOptionalAsync(new ConferenceSubscriptionId(command.MemberId.Value));

        if (conferenceSubscription == null)
        {
            conferenceSubscription = ConferenceSubscription.CreateForMember(command.MemberId, command.ExpirationDate);
            await _conferenceSubscriptionRepository.AddAsync(conferenceSubscription);
        }
        else
        {
            conferenceSubscription.ChangeExpirationDate(command.ExpirationDate);
        }

        return Unit.Value;
    }
}
