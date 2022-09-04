using EventService.Domain.Contracts;

namespace EventService.Domain.Members;

public class MemberId : IdValueBase
{
    public MemberId(Guid value) : base(value)
    {
    }
}