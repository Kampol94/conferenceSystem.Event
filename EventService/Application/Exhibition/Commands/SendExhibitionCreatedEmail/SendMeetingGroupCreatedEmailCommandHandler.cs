using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.BuildingBlocks.Application.Data;
using CompanyName.MyMeetings.BuildingBlocks.Application.Emails;
using CompanyName.MyMeetings.BuildingBlocks.Infrastructure;
using CompanyName.MyMeetings.BuildingBlocks.Infrastructure.Emails;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetAllExhibitions;
using CompanyName.MyMeetings.Modules.Meetings.Application.Members;
using Dapper;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.SendExhibitionCreatedEmail;

internal class SendExhibitionCreatedEmailCommandHandler : ICommandHandler<SendExhibitionCreatedEmailCommand>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IEmailSender _emailSender;

    public SendExhibitionCreatedEmailCommandHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IEmailSender emailSender)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(SendExhibitionCreatedEmailCommand request, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        var Exhibition = await connection.QuerySingleAsync<ExhibitionDto>(
            "SELECT " +
                              "[Exhibition].[Name], " +
                              "[Exhibition].[LocationCountryCode], " +
                              "[Exhibition].[LocationCity] " +
                              "FROM [meetings].[v_Exhibitions] AS [Exhibition] " +
                              "WHERE [Exhibition].[Id] = @Id", new
                              {
                                  Id = request.ExhibitionId.Value
                              });

        var member = await MembersQueryHelper.GetMember(request.CreatorId, connection);

        var email = new EmailMessage(
            member.Email,
            $"{Exhibition.Name} created",
            $"{Exhibition.Name} created at {Exhibition.LocationCity}, {Exhibition.LocationCountryCode}");

        _emailSender.SendEmail(email);

        return Unit.Value;
    }
}