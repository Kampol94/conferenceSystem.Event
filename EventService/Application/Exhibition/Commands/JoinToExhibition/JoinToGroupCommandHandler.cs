using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.JoinToGroup;

internal class JoinToGroupCommandHandler : ICommandHandler<JoinToGroupCommand>
{
    private readonly IExhibitionRepository _ExhibitionRepository;
    private readonly IMemberContext _memberContext;

    internal JoinToGroupCommandHandler(
        IExhibitionRepository ExhibitionRepository,
        IMemberContext memberContext)
    {
        _ExhibitionRepository = ExhibitionRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(JoinToGroupCommand request, CancellationToken cancellationToken)
    {
        var Exhibition = await _ExhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        Exhibition.JoinToGroupMember(_memberContext.MemberId);

        return Unit.Value;
    }
}