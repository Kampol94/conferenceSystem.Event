using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibition.Commands.LeaveExhibition;

public class LeaveExhibitionCommand : CommandBase
{
    public LeaveExhibitionCommand(Guid exhibitionId)
    {
        ExhibitionId = exhibitionId;
    }

    public Guid ExhibitionId { get; }
}