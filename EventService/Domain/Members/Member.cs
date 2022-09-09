using EventService.Domain.Contracts;
using EventService.Domain.Members.Events;

namespace EventService.Domain.Members;

public class Member : BaseEntity
{
    public MemberId Id { get; private set; }

    private readonly string _login;

    public string Email { get; private set; }

    private readonly string _firstName;

    private readonly string _lastName;

    private readonly string _name;

    private readonly DateTime _createDate;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Member()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public static Member Create(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        return new Member(id, login, email, firstName, lastName, name);
    }

    private Member(Guid id, string login, string email, string firstName, string lastName, string name)
    {
        Id = new MemberId(id);
        _login = login;
        Email = email;
        _firstName = firstName;
        _lastName = lastName;
        _name = name;
        _createDate = DateTime.Now; //TODO: add time provider for test proposes 

        AddDomainEvent(new MemberCreatedDomainEvent(Id));
    }
}