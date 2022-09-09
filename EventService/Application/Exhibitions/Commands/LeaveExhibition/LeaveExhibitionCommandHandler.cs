using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibitions.Commands.LeaveExhibition;

public class LeaveExhibitionCommandHandler : ICommandHandler<LeaveExhibitionCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    public LeaveExhibitionCommandHandler(
        IExhibitionRepository exhibitionRepository,
        IMemberContext memberContext)
    {
        _exhibitionRepository = exhibitionRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(LeaveExhibitionCommand request, CancellationToken cancellationToken)
    {
        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        exhibition.LeaveGroup(_memberContext.MemberId);

        return Unit.Value;
    }
}