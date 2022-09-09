using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;

namespace EventService.Application.Exhibitions.Commands.SetExhibitionExpirationDate;

public class SetExhibitionExpirationDateCommand : CommandBase
{
    public SetExhibitionExpirationDateCommand(Guid id, ExhibitionId exhibitionId, DateTime dateTo)
        : base(id)
    {
        ExhibitionId = exhibitionId;
        DateTo = dateTo;
    }

    public ExhibitionId ExhibitionId { get; }

    public DateTime DateTo { get; }
}