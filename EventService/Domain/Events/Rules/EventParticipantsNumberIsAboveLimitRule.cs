using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class EventParticipantsNumberIsAboveLimitRule : IBaseBusinessRule
{
    private readonly int? _participantsLimit;

    private readonly int _allActiveParticipants;

    public EventParticipantsNumberIsAboveLimitRule(
        int? participantsLimit,
        int allActiveParticipants)
    {
        _participantsLimit = participantsLimit;
        _allActiveParticipants = allActiveParticipants;
    }

    public bool IsBroken() => _participantsLimit.HasValue &&
                              _participantsLimit.Value < _allActiveParticipants + 1;

    public string Message => "Event is full";
}