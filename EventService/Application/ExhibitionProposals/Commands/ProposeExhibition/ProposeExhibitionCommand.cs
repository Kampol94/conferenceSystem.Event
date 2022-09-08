using EventService.Application.Contracts.Commands;

namespace EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;

public class ProposeExhibitionCommand : CommandBase<Guid>
{
    public ProposeExhibitionCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }
}