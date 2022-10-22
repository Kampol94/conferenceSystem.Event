using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibitions.Commands.JoinToExhibition;

public class JoinToExhibitionCommandHandler : ICommandHandler<JoinToExhibitionCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    public JoinToExhibitionCommandHandler(
        IExhibitionRepository exhibitionRepository,
        IMemberContext memberContext)
    {
        _exhibitionRepository = exhibitionRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(JoinToExhibitionCommand request, CancellationToken cancellationToken)
    {
        Exhibition? exhibition = await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        if (exhibition is null)
        {
            throw new Exception("Exhibition must exist.");
        }
        exhibition.AddMember(_memberContext.MemberId);

        return Unit.Value;
    }
}