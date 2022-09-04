namespace EventService.Domain.Contracts;

public interface IBaseBusinessRule
{
    bool IsBroken();

    string Message { get; }
}