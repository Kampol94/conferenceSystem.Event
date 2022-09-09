using EventService.Application.Contracts.Commands;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.Members.CreateMember;

public class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand>
{
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<Unit> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = Member.Create(request.MemberId, request.Login, request.Email, request.FirstName, request.LastName, request.Name);

        await _memberRepository.AddAsync(member);

        return Unit.Value;
    }
}