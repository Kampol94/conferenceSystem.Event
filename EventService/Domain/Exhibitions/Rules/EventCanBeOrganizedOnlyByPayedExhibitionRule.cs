using EventService.Domain.Contracts;

namespace EventService.Domain.Exhibitions.Rules;

public class EventCanBeOrganizedOnlyByPayedExhibitionRule : IBaseBusinessRule
{
    private readonly DateTime? _paymentDateTo;

    public EventCanBeOrganizedOnlyByPayedExhibitionRule(DateTime? paymentDateTo)
    {
        _paymentDateTo = paymentDateTo;
    }

    public bool IsBroken()
    {
        return !_paymentDateTo.HasValue || _paymentDateTo < DateTime.Now;
    }

    public string Message => "Meeting can be organized only by payed exhibition";
}