using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class ParticipantsLimitCannotBeChangedToSmallerThanActiveParticipantsRule : IBaseBusinessRule
{
    private readonly int? _participantsLimit;

    private readonly int _allActiveParticipantsWithGuestsNumber;

    public ParticipantsLimitCannotBeChangedToSmallerThanActiveParticipantsRule(
        EventLimits eventLimits,
        int allActiveParticipantsWithGuestsNumber)
    {
        _participantsLimit = eventLimits.ParticipantsLimit;
        _allActiveParticipantsWithGuestsNumber = allActiveParticipantsWithGuestsNumber;
    }

    public bool IsBroken() => _participantsLimit.HasValue && _participantsLimit.Value < _allActiveParticipantsWithGuestsNumber;

    public string Message => "Participants limit cannot be change to smaller than active participants number";
}