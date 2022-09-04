namespace EventService.Domain.Contracts;

public interface IBaseDomainEvent
{
    Guid Id { get; }

    DateTime When { get; }
}