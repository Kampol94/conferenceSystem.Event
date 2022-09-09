using EventService.Application.Contracts;
using EventService.Domain.Members;

namespace EventService.Application.Members;

public class MemberContext : IMemberContext
{
    private readonly IExecutionContextAccessor _executionContextAccessor;

    public MemberContext(IExecutionContextAccessor executionContextAccessor)
    {
        _executionContextAccessor = executionContextAccessor;
    }

    public MemberId MemberId => new(_executionContextAccessor.UserId);
}