using EventService.Domain.Contracts;

namespace EventService.Domain.EventReviews.Rules;

public class ReviewTextMustBeProvidedRule : IBaseBusinessRule
{
    private readonly string _text;

    public ReviewTextMustBeProvidedRule(string text)
    {
        _text = text;
    }

    public bool IsBroken() => string.IsNullOrEmpty(_text);

    public string Message => "Review text must be provided.";
}