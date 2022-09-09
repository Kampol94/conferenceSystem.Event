using EventService.Domain.Contracts;

namespace EventService.Domain.Events.Rules;

public class ReasonOfRemovingParticipantFromEventMustBeProvidedRule : IBaseBusinessRule
{
    private readonly string _reason;

    public ReasonOfRemovingParticipantFromEventMustBeProvidedRule(string reason)
    {
        _reason = reason;
    }

    public bool IsBroken()
    {
        return string.IsNullOrEmpty(_reason);
    }

    public string Message => "Reason of removing participant from event must be provided";
}