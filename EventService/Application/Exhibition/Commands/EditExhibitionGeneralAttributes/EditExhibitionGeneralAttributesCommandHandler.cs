using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibition.Commands.EditExhibitionGeneralAttributes;

internal class EditExhibitionGeneralAttributesCommandHandler : ICommandHandler<EditExhibitionGeneralAttributesCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IExhibitionRepository _exhibitionRepository;

    internal EditExhibitionGeneralAttributesCommandHandler(IMemberContext memberContext, IExhibitionRepository exhibitionRepository)
    {
        _memberContext = memberContext;
        _exhibitionRepository = exhibitionRepository;
    }

    public async Task<Unit> Handle(EditExhibitionGeneralAttributesCommand request, CancellationToken cancellationToken)
    {
        var exhibition =
            await _exhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        exhibition.EditGeneralAttributes(request.Name, request.Description);

        await _exhibitionRepository.Commit();

        return Unit.Value;
    }
}