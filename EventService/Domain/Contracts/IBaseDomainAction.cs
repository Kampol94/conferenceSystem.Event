namespace EventService.Domain.Contracts;

public interface IBaseDomainAction
{
    Guid Id { get; }

    DateTime When { get; }
}