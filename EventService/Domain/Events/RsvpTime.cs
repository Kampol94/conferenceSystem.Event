using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class RsvpTime : ValueObject
{
    public static RsvpTime NoTerm => new(null, null);

    public DateTime? StartDate { get; }

    public DateTime? EndDate { get; }

    public static RsvpTime CreateNewBetweenDates(DateTime? startDate, DateTime? endDate)
    {
        return new RsvpTime(startDate, endDate);
    }

    private RsvpTime(DateTime? startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    internal bool IsInTerm(DateTime date)
    {
        var left = !StartDate.HasValue || StartDate.Value <= date;

        var right = !EndDate.HasValue || EndDate.Value >= date;

        return left && right;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}