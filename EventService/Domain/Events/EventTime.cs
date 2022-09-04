using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class EventTime : ValueObject
{
    public DateTime StartDate { get; }

    public DateTime EndDate { get; }

    public static EventTime CreateNewBetweenDates(DateTime startDate, DateTime endDate)
    {
        return new EventTime(startDate, endDate);
    }

    private EventTime(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    internal bool IsAfterStart()
    {
        return DateTime.Now > StartDate; //TODO: add time provider for test proposes 
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}