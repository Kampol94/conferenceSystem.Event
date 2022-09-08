using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using MediatR;

namespace EventService.Application.Exhibition.Commands.SetExhibitionExpirationDate;

public class SetExhibitionExpirationDateCommandHandler : ICommandHandler<SetExhibitionExpirationDateCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;

    public SetExhibitionExpirationDateCommandHandler(IExhibitionRepository exhibitionRepository)
    {
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(SetExhibitionExpirationDateCommand request, CancellationToken cancellationToken)
    {
        var exhibition = await _exhibitionRepository.GetByIdAsync(request.ExhibitionId);

        exhibition.SetExpirationDate(request.DateTo);

        return Unit.Value;
    }
}