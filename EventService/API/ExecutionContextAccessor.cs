using EventService.Application.Contracts;

namespace EventService.API;

public class ExecutionContextAccessor : IExecutionContextAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            string userId = _httpContextAccessor
               .HttpContext?
               .User?
            .Claims?
               .SingleOrDefault(x => x.Type == MyClaimTypes.Id)?
               .Value ?? throw new ApplicationException("User context is not available");

            return new Guid(userId);
        }
    }

    public bool IsAvailable => _httpContextAccessor.HttpContext != null;
}
