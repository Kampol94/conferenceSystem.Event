using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Domain.Members;

public class MemberRepository : IMemberRepository
{
    private readonly EventsContext _meetingsContext;

    public MemberRepository(EventsContext meetingsContext)
    {
        _meetingsContext = meetingsContext;
    }

    public async Task AddAsync(Member member)
    {
        await _meetingsContext.Members.AddAsync(member);
    }

    public async Task<Member?> GetByIdAsync(MemberId memberId)
    {
        return await _meetingsContext.Members.FirstOrDefaultAsync(x => x.Id == memberId);
    }
}