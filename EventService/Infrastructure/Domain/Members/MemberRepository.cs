using EventService.Domain.Members;
using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Members;

internal class MemberRepository : IMemberRepository
{
    private readonly EventsContext _meetingsContext;

    internal MemberRepository(EventsContext meetingsContext)
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