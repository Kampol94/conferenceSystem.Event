using EventService.Application.Contracts;

namespace EventService.API;

public class ExecutionContextAccessor : IExecutionContextAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId => _httpContextAccessor
                .HttpContext?
                .User?
                .Claims?
                .SingleOrDefault(x => x.Type == "sub")?
                .Value != null
                ? Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(
                    x => x.Type == "sub").Value)
                : throw new ApplicationException("User context is not available");

    public bool IsAvailable => _httpContextAccessor.HttpContext != null;
}
