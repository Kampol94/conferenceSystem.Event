using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.EditExhibitionGeneralAttributes;

internal class EditExhibitionGeneralAttributesCommandHandler : ICommandHandler<EditExhibitionGeneralAttributesCommand>
{
    private readonly IMemberContext _memberContext;
    private readonly IExhibitionRepository _ExhibitionRepository;

    internal EditExhibitionGeneralAttributesCommandHandler(IMemberContext memberContext, IExhibitionRepository ExhibitionRepository)
    {
        _memberContext = memberContext;
        _ExhibitionRepository = ExhibitionRepository;
    }

    public async Task<Unit> Handle(EditExhibitionGeneralAttributesCommand request, CancellationToken cancellationToken)
    {
        Exhibition Exhibition =
            await _ExhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        Exhibition.EditGeneralAttributes(request.Name, request.Description, ExhibitionLocation.CreateNew(request.LocationCity, request.LocationCountry));

        await _ExhibitionRepository.Commit();

        return Unit.Value;
    }
}