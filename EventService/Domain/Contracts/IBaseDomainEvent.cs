using MediatR;

namespace EventService.Domain.Contracts;

public interface IBaseDomainEvent : INotification
{
    Guid Id { get; }

    DateTime When { get; }
}