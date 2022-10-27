using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibitions.Commands.EditExhibitionGeneralAttributes;

public class EditExhibitionGeneralAttributesCommandHandler : ICommandHandler<EditExhibitionGeneralAttributesCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;

    public EditExhibitionGeneralAttributesCommandHandler(IMemberContext memberContext, IExhibitionRepository exhibitionRepository)
    {
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(EditExhibitionGeneralAttributesCommand request, CancellationToken cancellationToken)
    {
        Exhibition? exhibition =
            await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));
        if (exhibition is null)
        {
            throw new ArgumentNullException("Exhibition does not exist", nameof(exhibition));
        }

        exhibition.EditGeneralAttributes(request.Name, request.Description);

        _ = await _exhibitionRepository.Commit();

        return Unit.Value;
    }
}