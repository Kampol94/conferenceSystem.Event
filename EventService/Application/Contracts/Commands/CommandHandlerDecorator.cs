using MediatR;
using System.Diagnostics;

namespace EventService.Application.Contracts.Commands;

public class CommandHandlerDecorator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{

    private readonly IRepository _repository;
    private readonly IMediator _mediator;
    private readonly ActivitySource _activitySource = new ActivitySource("EventService");

    public CommandHandlerDecorator(IRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        using var activity = _activitySource.StartActivity(typeof(TRequest).Name);
        try
        {
            TResponse? result = await next();

            using (var saveActivity = _activitySource.StartActivity("Save Data"))
            {
                await _repository.CommitAsync();
            }

            using (var saveActivity = _activitySource.StartActivity("Publish events"))
            {
                List<Domain.Contracts.BaseEntity> test = _repository.GetEntitiesWithEvents();
                await Parallel.ForEachAsync(test, async (entity, cancellationToken) =>
                {
                    await _mediator.Publish(entity.DequeueEvent(), cancellationToken);
                });
            }

            return result;
        }
        catch (Exception e)
        {
            activity?.SetStatus(ActivityStatusCode.Error, e.Message);
            throw;
        }
        
    }
}
