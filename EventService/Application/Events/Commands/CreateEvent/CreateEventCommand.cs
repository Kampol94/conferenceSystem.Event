using EventService.Application.Contracts.Commands;
using System.Text.Json.Serialization;

namespace EventService.Application.Events.Commands.CreateEvent;

public class CreateEventCommand : CommandBase<Guid>
{
    [JsonConstructor]
    public CreateEventCommand(
        Guid exhibitionId,
        string title,
        DateTime termStartDate,
        DateTime termEndDate,
        string description,
        int? participantsLimit,
        DateTime? rsvpTermStartDate,
        DateTime? rsvpTermEndDate,
        decimal? eventFeeValue,
        string eventFeeCurrency,
        List<Guid> hostMemberIds)
    {
        ExhibitionId = exhibitionId;
        Title = title;
        TermStartDate = termStartDate;
        TermEndDate = termEndDate;
        Description = description;
        ParticipantsLimit = participantsLimit;
        RSVPTermStartDate = rsvpTermStartDate;
        RSVPTermEndDate = rsvpTermEndDate;
        EventFeeValue = eventFeeValue;
        EventFeeCurrency = eventFeeCurrency;
        HostMemberIds = hostMemberIds;
    }

    public Guid ExhibitionId { get; }

    public string Title { get; }

    public DateTime TermStartDate { get; }

    public DateTime TermEndDate { get; }

    public string Description { get; }

    public int? ParticipantsLimit { get; }

    public DateTime? RSVPTermStartDate { get; }

    public DateTime? RSVPTermEndDate { get; }

    public decimal? EventFeeValue { get; }

    public string EventFeeCurrency { get; }

    public List<Guid> HostMemberIds { get; }
}