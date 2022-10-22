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
        Event? @event = await _eventRepository.GetByIdAsync(notification.EventId);

        if (@event is null)
        {
            throw new Exception("Event must exist."); // TODO: custom exception
        }

        Member? participant = await _memberRepository.GetByIdAsync(notification.ParticipantId);

        if (participant is null)
        {
            throw new Exception("Participant must exist."); // TODO: custom exception
        }

        EmailMessage email = new(
            participant.Email,
            $"You joined to {@event.Title} event.",
            $"You joined to {@event.Title} title at {@event.Time.StartDate.ToShortDateString()} - {@event.Time.EndDate.ToShortDateString()}");

        _emailSender.SendEmail(email);
    }
}