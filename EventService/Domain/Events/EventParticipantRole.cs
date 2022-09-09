using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class EventParticipantRole : ValueObject
{
    public static EventParticipantRole Host => new("Host");

    public static EventParticipantRole Participant => new("Participant");

    public string Value { get; }

    private EventParticipantRole(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}