namespace EventService.Application.Events.Query.GetEventDetails;

public class GetEventDetailsRespone
{
    public Guid Id { get; set; }

    public Guid ExhibitionId { get; set; }

    public string? Title { get; set; }

    public DateTime TermStartDate { get; set; }

    public DateTime TermEndDate { get; set; }

    public string? Description { get; set; }

    public int? ParticipantsLimit { get; set; }

    public DateTime? RSVPTermStartDate { get; set; }

    public DateTime? RSVPTermEndDate { get; set; }

    public decimal? EventFeeValue { get; set; }

    public string? EventFeeCurrency { get; set; }
}