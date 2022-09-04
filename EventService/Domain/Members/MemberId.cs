using EventService.Domain.Contracts;

namespace EventService.Domain.Members;

public class MemberId : IdValueBase
{
    protected MemberId(Guid value) : base(value)
    {
    }
}