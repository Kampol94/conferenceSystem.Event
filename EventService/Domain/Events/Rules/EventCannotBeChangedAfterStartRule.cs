using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class EventCannotBeChangedAfterStartRule : IBaseBusinessRule
{
    private readonly EventTime _eventTerm;

    public EventCannotBeChangedAfterStartRule(EventTime eventTerm)
    {
        _eventTerm = eventTerm;
    }

    public bool IsBroken()
    {
        return _eventTerm.IsAfterStart();
    }

    public string Message => "Event cannot be changed after start";
}