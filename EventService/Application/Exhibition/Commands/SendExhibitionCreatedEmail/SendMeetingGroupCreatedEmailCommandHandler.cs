using EventService.Application.Contracts.Commands;
using EventService.Application.Emails;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Exhibition.Commands.SendExhibitionCreatedEmail;

public class SendExhibitionCreatedEmailCommandHandler : ICommandHandler<SendExhibitionCreatedEmailCommand>
{
    private readonly IEmailSender _emailSender;
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMemberRepository _memberRepository;

    public SendExhibitionCreatedEmailCommandHandler(IEmailSender emailSender, IExhibitionRepository exhibitionRepository, IMemberRepository memberRepository)
    {
        _emailSender = emailSender;
        _exhibitionRepository = exhibitionRepository;
        _memberRepository = memberRepository;
    }

    public async Task<Unit> Handle(SendExhibitionCreatedEmailCommand request, CancellationToken cancellationToken)
    {
        var exhibition = await _exhibitionRepository.GetByIdAsync(request.ExhibitionId);

        var member = await _memberRepository.GetByIdAsync(request.CreatorId);

        var email = new EmailMessage(
            member.Email,
            $"{exhibition.Name} created",
            $"We are happy to inform that {exhibition.Name} is created ");

        _emailSender.SendEmail(email);

        return Unit.Value;
    }
}