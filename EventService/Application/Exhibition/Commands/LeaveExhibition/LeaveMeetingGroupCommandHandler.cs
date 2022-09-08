using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.LeaveExhibition;

internal class LeaveExhibitionCommandHandler : ICommandHandler<LeaveExhibitionCommand>
{
    private readonly IExhibitionRepository _ExhibitionRepository;
    private readonly IMemberContext _memberContext;

    internal LeaveExhibitionCommandHandler(
        IExhibitionRepository ExhibitionRepository,
        IMemberContext memberContext)
    {
        _ExhibitionRepository = ExhibitionRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(LeaveExhibitionCommand request, CancellationToken cancellationToken)
    {
        var Exhibition = await _ExhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        Exhibition.LeaveGroup(_memberContext.MemberId);

        return Unit.Value;
    }
}