using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class EventLocation : ValueObject
{
    public static EventLocation CreateNew(string name, string address, string postalCode, string city)
    {
        return new EventLocation(name, address, postalCode, city);
    }

    private EventLocation(string name, string address, string postalCode, string city)
    {
        Name = name;
        Address = address;
        PostalCode = postalCode;
        City = city;
    }

    public string Name { get; }

    public string Address { get; }

    public string PostalCode { get; }

    public string City { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return PostalCode;
        yield return City;
    }
}