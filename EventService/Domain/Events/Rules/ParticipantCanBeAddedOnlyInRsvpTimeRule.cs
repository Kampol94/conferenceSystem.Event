using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class ParticipantCanBeAddedOnlyInRsvpTimeRule : IBaseBusinessRule
{
    private readonly RsvpTime _rsvpTime;

    public ParticipantCanBeAddedOnlyInRsvpTimeRule(RsvpTime rsvpTime)
    {
        _rsvpTime = rsvpTime;
    }

    public bool IsBroken() => !_rsvpTime.IsInTerm(DateTime.Now); //TODO: add time provider for test proposes 

    public string Message => "Participant can be added only within the time allowed";
}