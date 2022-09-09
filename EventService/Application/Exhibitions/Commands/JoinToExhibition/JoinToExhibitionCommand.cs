using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibitions.Commands.JoinToExhibition;

public class JoinToExhibitionCommand : CommandBase
{
    public JoinToExhibitionCommand(Guid exhibitionId)
    {
        ExhibitionId = exhibitionId;
    }

    public Guid ExhibitionId { get; }
}