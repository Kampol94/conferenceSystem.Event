using MediatR;

namespace EventService.Application.Contracts.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}