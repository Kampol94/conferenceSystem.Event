using MediatR;

namespace EventService.Application.Contracts.Commands;

public class CommitBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    private readonly IRepository _repository;
    private readonly IMediator _mediator;

    public CommitBehavior(IRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        TResponse? result = await next();
        _ = await _repository.CommitAsync();

        List<Domain.Contracts.BaseEntity> test = _repository.GetEntitiesWithEvents();

        await Parallel.ForEachAsync(test, async (entity, cancellationToken) =>
        {
            await _mediator.Publish(entity.DequeueEvent(), cancellationToken);
        });

        return result;
    }
}
