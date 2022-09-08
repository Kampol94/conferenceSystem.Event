using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibition.Commands.JoinToExhibition;

internal class JoinToExhibitionCommandHandler : ICommandHandler<JoinToExhibitionCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberContext _memberContext;

    internal JoinToExhibitionCommandHandler(
        IExhibitionRepository exhibitionRepository,
        IMemberContext memberContext)
    {
        _exhibitionRepository = exhibitionRepository;
        _memberContext = memberContext;
    }

    public async Task<Unit> Handle(JoinToExhibitionCommand request, CancellationToken cancellationToken)
    {
        var exhibition = await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        exhibition.AddMember(_memberContext.MemberId);

        return Unit.Value;
    }
}