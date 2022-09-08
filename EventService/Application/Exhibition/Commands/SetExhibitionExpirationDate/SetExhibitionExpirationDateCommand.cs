using EventService.Domain.Exhibitions;
using MediatR;

namespace EventService.Application.Exhibition.Commands.SetMeetingGroupExpirationDate;
internal class SetExhibitionExpirationDateCommand : IRequest<object>
{
    private Guid _guid;
    private ExhibitionId _id;
    private DateTime _expirationDate;

    public SetExhibitionExpirationDateCommand(Guid guid, ExhibitionId id, DateTime expirationDate)
    {
        _guid = guid;
        _id = id;
        _expirationDate = expirationDate;
    }
}