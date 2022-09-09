using EventService.Application.Emails;
using EventService.Domain.Events;
using EventService.Domain.Events.DomainEvent;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Events.DomainEventHandlers.EventParticipantAddedDomainEvents;

public class EventParticipantAddedHandler : INotificationHandler<EventParticipantAddedDomainEvent>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMemberRepository _memberRepository;
    private readonly IEmailSender _emailSender;

    public EventParticipantAddedHandler(IEventRepository eventRepository, IMemberRepository memberRepository, IEmailSender emailSender)
    {
        _eventRepository = eventRepository;
        _memberRepository = memberRepository;
        _emailSender = emailSender;
    }

    public async Task Handle(EventParticipantAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(notification.EventId);

        var participant = await _memberRepository.GetByIdAsync(notification.ParticipantId);

        var email = new EmailMessage(
            participant.Email,
            $"You joined to {@event.Title} event.",
            $"You joined to {@event.Title} title at {@event.Time.StartDate.ToShortDateString()} - {@event.Time.EndDate.ToShortDateString()}");

        _emailSender.SendEmail(email);
    }
}