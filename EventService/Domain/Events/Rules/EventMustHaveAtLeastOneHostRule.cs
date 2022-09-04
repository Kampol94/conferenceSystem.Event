using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class EventMustHaveAtLeastOneHostRule : IBaseBusinessRule
{
    private readonly int _eventHostNumber;

    public EventMustHaveAtLeastOneHostRule(int eventHostNumber)
    {
        _eventHostNumber = eventHostNumber;
    }

    public bool IsBroken() => _eventHostNumber == 0;

    public string Message => "Event must have at least one host";
}