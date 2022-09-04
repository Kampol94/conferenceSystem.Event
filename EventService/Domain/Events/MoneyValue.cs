using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class Money : ValueObject
{
    public static Money Undefined => new Money(null, null);

    public decimal? Value { get; }

    public string? Currency { get; }

    public static Money Of(decimal value, string currency)
    {
        return new Money(value, currency);
    }

    private Money(decimal? value, string? currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Money operator *(int left, Money right)
    {
        return new Money(right.Value * left, right.Currency);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }
}