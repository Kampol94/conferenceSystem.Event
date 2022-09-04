using EventService.Domain.Contracts;
using EventService.Domain.Events.Rules;

namespace EventService.Domain.Events;

public class EventLimits : ValueObject
{
    public int? ParticipantsLimit { get; }

    private EventLimits(int? participantsLimit)
    {
        ParticipantsLimit = participantsLimit;
    }

    public static EventLimits Create(int? participantsLimit)
    {
        CheckRule(new EventParticipantsLimitCannotBeNegativeRule(participantsLimit));

        return new EventLimits(participantsLimit);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ParticipantsLimit;
    }
}