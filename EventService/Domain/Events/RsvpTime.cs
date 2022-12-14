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

    public bool IsInTerm(DateTime date)
    {
        bool left = !StartDate.HasValue || StartDate.Value <= date;

        bool right = !EndDate.HasValue || EndDate.Value >= date;

        return left && right;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}