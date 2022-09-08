namespace EventService.Application.Exhibition.Queries.GetAuthenticationMemberMeetingGroups;

public class MemberExhibitionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? LocationCountryCode { get; set; }

    public string? LocationCity { get; set; }

    public Guid MemberId { get; set; }

    public string? RoleCode { get; set; }
}