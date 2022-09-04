using EventService.Domain.Contracts;

namespace EventService.Domain.Exhibitions.Events;

public class ExhibitionGeneralAttributesEditedDomainEvent : DomainEventBase
{
    public string NewName { get; }

    public string NewDescription { get; }

    public ExhibitionGeneralAttributesEditedDomainEvent(string newName, string newDescription)
    {
        NewName = newName;
        NewDescription = newDescription;
    }
}
