namespace EventService.Application.Contracts;

internal interface IExecutionContextAccessor
{
    object UserId { get; set; }
}