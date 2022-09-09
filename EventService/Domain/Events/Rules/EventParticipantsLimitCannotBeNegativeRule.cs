using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class EventParticipantsLimitCannotBeNegativeRule : IBaseBusinessRule
{
    private readonly int? _participantsLimit;

    public EventParticipantsLimitCannotBeNegativeRule(int? participantsLimit)
    {
        _participantsLimit = participantsLimit;
    }

    public bool IsBroken()
    {
        return _participantsLimit.HasValue && _participantsLimit.Value < 0;
    }

    public string Message => "Participants limit cannot be negative";
}