using MediatR;

namespace EventService.Application.Contracts.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}