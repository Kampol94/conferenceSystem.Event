using EventService.Application.Contracts.Commands;
using EventService.Domain.ExhibitionProposals;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.CreateNewExhibition;

public class CreateNewExhibitionCommand : CommandBase
{
    public CreateNewExhibitionCommand(Guid id, ExhibitionProposalId ExhibitionProposalId)
        : base(id)
    {
        this.ExhibitionProposalId = ExhibitionProposalId;
    }

    internal ExhibitionProposalId ExhibitionProposalId { get; }
}