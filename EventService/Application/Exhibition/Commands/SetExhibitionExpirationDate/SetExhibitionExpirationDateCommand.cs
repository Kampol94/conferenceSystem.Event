using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibition.Commands.SetExhibitionExpirationDate;

public class SetExhibitionExpirationDateCommand : CommandBase
{
    public SetExhibitionExpirationDateCommand(Guid id, Guid exhibitionId, DateTime dateTo)
        : base(id)
    {
        ExhibitionId = exhibitionId;
        DateTo = dateTo;
    }

    internal Guid ExhibitionId { get; }

    internal DateTime DateTo { get; }
}