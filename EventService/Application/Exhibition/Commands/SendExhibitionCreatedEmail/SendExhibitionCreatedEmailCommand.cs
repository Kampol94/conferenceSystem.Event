using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Application.Exhibition.Commands.SendExhibitionCreatedEmail;

public class SendExhibitionCreatedEmailCommand : CommandBase
{
    public ExhibitionId ExhibitionId { get; }

    public MemberId CreatorId { get; }

    public SendExhibitionCreatedEmailCommand(Guid id, ExhibitionId exhibitionId, MemberId creatorId)
        : base(id)
    {
        ExhibitionId = exhibitionId;
        CreatorId = creatorId;
    }
}