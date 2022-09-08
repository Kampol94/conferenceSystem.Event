using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;

namespace EventService.Application.Exhibition.Commands.SetExhibitionExpirationDate;

public class SetExhibitionExpirationDateCommand : CommandBase
{
    public SetExhibitionExpirationDateCommand(Guid id, ExhibitionId exhibitionId, DateTime dateTo)
        : base(id)
    {
        ExhibitionId = exhibitionId;
        DateTo = dateTo;
    }

    internal ExhibitionId ExhibitionId { get; }

    internal DateTime DateTo { get; }
}