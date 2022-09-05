using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.ChangeEventMainAttributes;

public class ChangeEventMainAttributesCommand : CommandBase
{
    public ChangeEventMainAttributesCommand(
        Guid eventId,
        string title,
        DateTime termStartDate,
        DateTime termEndDate,
        string description,
        int? participantsLimit,
        DateTime? rsvpTermStartDate,
        DateTime? rsvpTermEndDate,
        decimal? eventFeeValue,
        string eventFeeCurrency)
    {
        EventId = eventId;
        Title = title;
        TermStartDate = termStartDate;
        TermEndDate = termEndDate;
        Description = description;
        ParticipantsLimit = participantsLimit;
        RSVPTermStartDate = rsvpTermStartDate;
        RSVPTermEndDate = rsvpTermEndDate;
        EventFeeValue = eventFeeValue;
        EventFeeCurrency = eventFeeCurrency;
    }

    public Guid EventId { get; }

    public string Title { get; }

    public DateTime TermStartDate { get; }

    public DateTime TermEndDate { get; }

    public string Description { get; }

    public int? ParticipantsLimit { get; }

    public DateTime? RSVPTermStartDate { get; }

    public DateTime? RSVPTermEndDate { get; }

    public decimal? EventFeeValue { get; }

    public string EventFeeCurrency { get; }
}