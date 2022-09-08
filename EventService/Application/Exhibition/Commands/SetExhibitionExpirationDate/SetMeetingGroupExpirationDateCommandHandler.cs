using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Exhibitions;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.SetExhibitionExpirationDate;

internal class SetExhibitionExpirationDateCommandHandler : ICommandHandler<SetExhibitionExpirationDateCommand>
{
    private readonly IExhibitionRepository _ExhibitionRepository;

    internal SetExhibitionExpirationDateCommandHandler(IExhibitionRepository ExhibitionRepository)
    {
        _ExhibitionRepository = ExhibitionRepository;
    }

    public async Task<Unit> Handle(SetExhibitionExpirationDateCommand request, CancellationToken cancellationToken)
    {
        var Exhibition = await _ExhibitionRepository.GetByIdAsync(new ExhibitionId(request.ExhibitionId));

        Exhibition.SetExpirationDate(request.DateTo);

        return Unit.Value;
    }
}